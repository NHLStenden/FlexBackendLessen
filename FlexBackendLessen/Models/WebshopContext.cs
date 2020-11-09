using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FlexBackendLessen.Models
{
    public class WebshopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public WebshopContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Product>().HasData(new List<Product>()
            // {
            //     new Product() { Description = "Product 1" },
            //     new Product() { Description = "Product 2" }
            // });

        }
    }
}
