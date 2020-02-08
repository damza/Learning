using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.TaxCalculations.Any())
            {
                var calcs = new TaxCalculation[]
                {
                    new TaxCalculation
                    {
                        PostalCode = "7000",
                        AnnualIncome = 100000M,
                        TaxResult = 17500M,
                        Timestamp = DateTime.Now
                    }
                };

                foreach (var c in calcs)
                {
                    context.TaxCalculations.Add(c);
                }
                context.SaveChanges();
            }

            if (!context.TaxTypes.Any())
            {
                var taxTypes = new TaxType[]
                {
                    new TaxType
                    {
                        PostalCode = "7441",
                        Type = "Progressive"
                    },
                    new TaxType
                    {
                        PostalCode = "A100",
                        Type = "Flat Value"
                    },
                    new TaxType
                    {
                        PostalCode = "7000",
                        Type = "Flat Rate"
                    },
                    new TaxType
                    {
                        PostalCode = "1000",
                        Type = "Progressive"
                    },
                };

                foreach (var t in taxTypes)
                {
                    context.TaxTypes.Add(t);
                }
                context.SaveChanges();
            }
        }
    }
}
