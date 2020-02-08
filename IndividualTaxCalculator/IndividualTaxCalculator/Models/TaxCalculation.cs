using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayName("Annual Income")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal AnnualIncome { get; set; }
               

        [DisplayName("Tax Result")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TaxResult { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
