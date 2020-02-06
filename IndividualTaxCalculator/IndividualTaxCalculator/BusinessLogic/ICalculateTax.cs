using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.BusinessLogic
{
    public interface ICalculateTax
    {
        decimal CalculateProgressiveTax(string postalCode, decimal annualIncome);

        decimal CalculateFlatValueTax(string postalCode, decimal annualIncome);

        decimal CalculateRateTax(string postalCode, decimal annualIncome);

    }
}
