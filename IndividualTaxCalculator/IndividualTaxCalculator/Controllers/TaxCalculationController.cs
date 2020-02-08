using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IndividualTaxCalculator.BusinessLogic;
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
            ViewData["PostalCodes"] = _dataLayer.GetAllPostalCodes();

            

            return View();
        }

        //private static List<SelectListItem> GetPostalCodes()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>
        //    {
        //        new SelectListItem
        //        {
        //            Text = "Select Postal Code",
        //            Value = "0",
        //            Selected = true
        //        },

        //        new SelectListItem
        //        {
        //            Text = "7441",
        //            Value = "7441"
        //        },

        //        new SelectListItem
        //        { 
        //            Text = "A100", 
        //            Value = "A100" 
        //        },

        //        new SelectListItem
        //        { 
        //            Text = "7000", 
        //            Value = "7000" 
        //        },

        //        new SelectListItem
        //        { 
        //            Text = "1000", 
        //            Value = "1000" 
        //        }
        //    };

        //    return items;
        //}
    }
}