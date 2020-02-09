using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [BindNever]
        public int Id { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Please enter a value greater than {1}")]
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
