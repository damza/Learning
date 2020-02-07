using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public class TaxCalculation
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [DisplayName("Annual Incode")]
        [DataType(DataType.Currency)]
        public decimal AnnualIncome { get; set; }
        public decimal TaxResult { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
