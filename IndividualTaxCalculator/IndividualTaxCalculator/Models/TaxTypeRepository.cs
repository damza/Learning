using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public class TaxTypeRepository: ITaxTypeRepository
    {
        private readonly AppDbContext _appDbContext;
        public TaxTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<TaxType> GetAllTaxTypes()
        {
            return _appDbContext.TaxTypes;
        }
    }

}
