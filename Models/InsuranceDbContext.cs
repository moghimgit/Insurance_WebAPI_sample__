using Insurance_WebAPI_sample__.Model;
using Microsoft.EntityFrameworkCore;

namespace Insurance_WebAPI_sample__.Models
{
    public class InsuranceDbContext : DbContext
    {

        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }
        public DbSet<InsuranceRequest> InsuranceRequests { get; set; }
        public DbSet<Coverage> Coverages { get; set; }
        public DbSet<CoverageSelection> CoverageSelections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coverage>().HasData(
                new Coverage { CoverageId = 1, CoverageName = "جراحی", MinInvestment = 5000, MaxInvestment = 500000000, Rate = 0.0052M },
                new Coverage { CoverageId = 2, CoverageName = "دندانپزشکی", MinInvestment = 4000, MaxInvestment = 400000000, Rate = 0.0042M },
                new Coverage { CoverageId = 3, CoverageName = "بستری", MinInvestment = 2000, MaxInvestment = 200000000, Rate = 0.005M }
            );
        }


    }
}
