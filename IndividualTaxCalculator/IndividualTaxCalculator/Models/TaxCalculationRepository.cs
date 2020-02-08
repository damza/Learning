using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public class TaxCalculationRepository: ITaxCalculationRepository
    {
        private readonly AppDbContext _appDbContext;
        public TaxCalculationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TaxCalculation> GetAllTaxCalculations()
        {
            return _appDbContext.TaxCalculations;
        }
    }

}
