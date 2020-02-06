using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.BusinessLogic
{
    public class CalculateTax : ICalculateTax
    {
        public decimal CalculateFlatValueTax(string postalCode, decimal annualIncome)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateProgressiveTax(string postalCode, decimal annualIncome)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateRateTax(string postalCode, decimal annualIncome)
        {
            throw new NotImplementedException();
        }
    }
}
