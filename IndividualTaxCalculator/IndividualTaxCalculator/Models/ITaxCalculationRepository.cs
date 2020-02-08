using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public interface ITaxCalculationRepository
    {
        IEnumerable<TaxCalculation> GetAllTaxCalculations();
    }
}
