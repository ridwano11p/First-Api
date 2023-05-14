using Microsoft.EntityFrameworkCore;

namespace Firstapi.Models
{
    public class BrandContext : DbContext
    {
        // Define a constructor that accepts a DbContextOptions object and passes it to the base constructor
        public BrandContext(DbContextOptions<BrandContext> options) : base(options)
        {
        }

        // Define a DbSet property for each entity set
        public DbSet<Brand> Brands { get; set; }
    }
}