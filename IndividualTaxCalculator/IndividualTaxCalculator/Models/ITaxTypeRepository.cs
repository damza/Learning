using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public interface ITaxTypeRepository
    {
        IEnumerable<TaxType> GetAllTaxTypes();
    }
}
