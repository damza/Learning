using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IndividualTaxCalculator.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<TaxCalculation> TaxCalculations { get; set; }

        public DbSet<TaxType> TaxTypes { get; set; }
    }
}
