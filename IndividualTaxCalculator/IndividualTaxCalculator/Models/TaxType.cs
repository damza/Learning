using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public class TaxType
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [DisplayName("Tax Type")]
        public string Type { get; set; }
    }
}
