using IndividualTaxCalculator.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.BusinessLogic
{
    public class DataLayer : IDataLayer
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITaxTypeRepository _taxType;

        public DataLayer(AppDbContext appDbContext, ITaxTypeRepository taxType)
        {
            _appDbContext = appDbContext;
            _taxType = taxType;
        }

        public void AddNewTaxCalculationResult(TaxCalculation taxCalculation)
        {
            _appDbContext.Add<TaxCalculation>(taxCalculation);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetAllPostalCodes()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(
                new SelectListItem
                {
                    Text = "Select Postal Code",
                    Value = "0",
                    Selected = true
                });

            if (_taxType.GetAllTaxTypes().Any())
            {
                foreach (var i in _taxType.GetAllTaxTypes())
                {
                    list.Add(new SelectListItem
                    {
                        Text = i.PostalCode,
                        Value = i.PostalCode
                    });
                }
            }
            
            return list;
        }

        public IEnumerable<TaxType> GetAllPostalCodeTypes()
        {
            return _taxType.GetAllTaxTypes();
        }
    }
}
