using CarInsurance.Models;
using Microsoft.EntityFrameworkCore;

namespace CarInsurance.Data
{
    public class CarInsuranceContext : DbContext
    {
        // Constructor receives the database configuration.
        public CarInsuranceContext(DbContextOptions<CarInsuranceContext> options)
            : base(options)
        {
        }

        // Represents the Insurees table in the database.
        public DbSet<Insuree> Insurees { get; set; } = default!;
    }
}
