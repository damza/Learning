using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.BusinessLogic
{
    public interface ICalculateTax
    {
        decimal CalculateFlatValueTax(decimal annualIncome);

        decimal CalculateFlatRateTax(decimal annualIncome);

        decimal CalculateProgressiveTax(decimal annualIncome);

    }
}
