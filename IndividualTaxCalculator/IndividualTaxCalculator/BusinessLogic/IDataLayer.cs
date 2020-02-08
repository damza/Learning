using IndividualTaxCalculator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.BusinessLogic
{
    public interface IDataLayer
    {
        IEnumerable<SelectListItem> GetAllPostalCodes();

        void AddNewTaxCalculationResult(TaxCalculation taxCalculation);
    }
}
