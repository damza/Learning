using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using IndividualTaxCalculator.BusinessLogic;
using IndividualTaxCalculator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IndividualTaxCalculator.Controllers
{
    [Route("api/TaxServices")]
    [ApiController]
    public class TaxServicesController : ControllerBase
    {
        private readonly ICalculateTax _calculateTax;
        private readonly IDataLayer _dataLayer;

        public TaxServicesController(ICalculateTax calculateTax, IDataLayer dataLayer)
        {
            _dataLayer = dataLayer;
            _calculateTax = calculateTax;
        }

        [HttpGet]
        public IActionResult GetPostalCodes()
        {            
            var codes = _dataLayer.GetAllPostalCodeTypes();

            if(codes == null)
            {
                return NotFound();
            }

            return Ok(codes);

        }


        [HttpPost]
        [ResponseType(typeof(string))]
        [Route("CalculateTax")]
        public IActionResult CalculateTax(string taxType, [FromBody]TaxCalculation taxCalcModel)
        {
            decimal tax = 0M;

            string postalCode = taxCalcModel.PostalCode;
            decimal annualIncome = taxCalcModel.AnnualIncome;

            switch(taxType)
            {
                case "Progressive":
                    tax = _calculateTax.CalculateProgressiveTax(annualIncome);
                    break;
                case "Flat Value":
                    tax = _calculateTax.CalculateFlatValueTax(annualIncome);
                    break;
                case "Flat Rate":
                    tax = _calculateTax.CalculateFlatRateTax(annualIncome);
                    break;
            }

            TaxCalculation calculation = new TaxCalculation()
            {
                AnnualIncome = annualIncome,
                PostalCode = postalCode,
                TaxResult = tax,
                Timestamp = DateTime.Now
            };

            //Insert result in database
            _dataLayer.AddNewTaxCalculationResult(calculation);

            return Ok(tax.ToString());
        }
    }
}