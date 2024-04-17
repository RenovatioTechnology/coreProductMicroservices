using Microsoft.EntityFrameworkCore;

namespace coreProductMicroservices.Models
{
    public class ProductDbContext:DbContext
    {
        public DbSet<Product> Products { get; set;}
        /*Adding the constructor ProductDbContext to inject the
        BContext created as a dependency into program.cs.*/
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        // add-migration InitialMigrate and update-database
    }
}
