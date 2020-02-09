using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IndividualTaxCalculator.BusinessLogic;
using IndividualTaxCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace IndividualTaxCalculator.Controllers
{
    public class TaxCalculationController : Controller
    {
        private readonly IConfiguration _configuration;

        public TaxCalculationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        public IActionResult Index()
        {
            ViewBag.Title = "Calculate Income Tax";
            ViewBag.Message = "Hello, this is a tax calculation tool!";
                       

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit(TaxCalculation model)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<TaxType> postalCodes = null;
                decimal calculationResult = 0M;

                string baseUri = _configuration["ApiBaseUri:BaseUri"];

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(baseUri);

                    using (var response = await client.GetAsync($"{baseUri}TaxServices"))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        postalCodes = JsonConvert.DeserializeObject<List<TaxType>>(apiResponse);
                    }
                }

                var singlePostalcode = postalCodes.Where(p => p.PostalCode == model.PostalCode);
                if (!singlePostalcode.Any())
                {
                    ModelState.AddModelError("PostalCode", "Postal Code is not catered for, please enter postal code from this selection (7441, A100, 7000, 1000).");
                    return View("Index", model);
                }
                else
                {
                    //call api to calculate tax and insert in database
                    string taxType = singlePostalcode.FirstOrDefault().Type;

                    TaxCalculation calculation = new TaxCalculation()
                    {
                        AnnualIncome = model.AnnualIncome,
                        PostalCode = model.PostalCode,
                    };

                    var client = new RestClient(baseUri);
                    
                    string url = $"{baseUri}TaxServices/CalculateTax/";

                    var request = new RestRequest(url, Method.POST);
                    var json = JsonConvert.SerializeObject(calculation);
                    request.AddParameter("taxType", taxType, ParameterType.QueryString);
                    request.AddParameter("text/json", json, ParameterType.RequestBody);

                    var response = client.Execute(request);

                    string strCalculationResult = JsonConvert.DeserializeObject<string>(response.Content);

                    calculationResult = Convert.ToDecimal(strCalculationResult);


                }

                var postalCode = model.PostalCode;
                var annualIncome = model.AnnualIncome;
                var taxResult = calculationResult;
                return RedirectToAction("TaxCalculationSubmitted", new { postalCode, annualIncome, taxResult });
            }
            else
            {
                return View("Index", model);
            }
        }

        public IActionResult TaxCalculationSubmitted(string postalCode, decimal annualIncome, decimal taxResult)
        {
            ViewBag.Title = "Tax Calculation Submitted";
            ViewBag.Message = $"Hello, thank you for submitting your tax calculation! The result for the annual income {annualIncome} for postal code {postalCode} is {taxResult}";

            return View();
        }
    }
}