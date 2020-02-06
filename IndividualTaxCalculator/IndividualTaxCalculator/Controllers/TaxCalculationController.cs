using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualTaxCalculator.BusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace IndividualTaxCalculator.Controllers
{
    public class TaxCalculationController : Controller
    {
        private readonly ICalculateTax _calculateTax;

        public TaxCalculationController(ICalculateTax calculateTax)
        {
            _calculateTax = calculateTax ?? throw new ArgumentNullException($"{nameof(ICalculateTax)} cannot be null.");
        }

        
        public IActionResult Index()
        {
            ViewBag.Message = "Hello, this is a tax calculation tool!";

            return View();
        }
    }
}