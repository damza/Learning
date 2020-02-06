using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public class TaxCalculation
    {
        public int Id { get; set; }
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal TaxResult { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
