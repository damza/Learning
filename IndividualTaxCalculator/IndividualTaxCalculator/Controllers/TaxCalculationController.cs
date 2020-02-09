using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualTaxCalculator.BusinessLogic;
using IndividualTaxCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IndividualTaxCalculator.Controllers
{
    public class TaxCalculationController : Controller
    {
        private readonly ICalculateTax _calculateTax;
        private readonly IDataLayer _dataLayer;

        public TaxCalculationController(ICalculateTax calculateTax, IDataLayer dataLayer)
        {
            _calculateTax = calculateTax ?? throw new ArgumentNullException($"{nameof(ICalculateTax)} cannot be null.");
            _dataLayer = dataLayer ?? throw new ArgumentNullException($"{nameof(IDataLayer)} cannot be null.");
        }

        
        public IActionResult Index()
        {
            ViewBag.Title = "Calculate Income Tax";
            ViewBag.Message = "Hello, this is a tax calculation tool!";
                       

            return View();
        }

        [HttpPost]
        public IActionResult Submit(TaxCalculation model)
        {
            if (ModelState.IsValid)
            {
                var postalCodes = _dataLayer.GetAllPostalCodeTypes();

                if (!postalCodes.Where(p => p.PostalCode == model.PostalCode).Any())
                {
                    ModelState.AddModelError("PostalCode", "Postal Code is not catered for, please enter postal code from this selection (7441, A100, 7000, 1000).");
                    return View("Index", model);
                }
                else
                {
                    //call api to calculate tax and insert in database
                    _dataLayer.AddNewTaxCalculationResult(model);
                }

                var postalCode = "";
                var annualIncome = "";
                var taxResult = "";
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