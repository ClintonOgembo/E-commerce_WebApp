using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed categories
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "Electronic devices and accessories" },
                new Category { Id = 2, Name = "Clothing", Description = "Apparel and fashion" },
                new Category { Id = 3, Name = "Home & Kitchen", Description = "Home appliances and kitchenware" }
            );

            // Seed sample products
            builder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Wireless Headphones", Description = "High quality Bluetooth headphones with noise cancellation.", Price = 4999.00m, Stock = 50, CategoryId = 1, ImageUrl = "/images/placeholder.jpg" },
                new Product { Id = 2, Name = "Men's T-Shirt", Description = "100% cotton casual t-shirt, available in multiple colours.", Price = 799.00m, Stock = 200, CategoryId = 2, ImageUrl = "/images/placeholder.jpg" },
                new Product { Id = 3, Name = "Coffee Maker", Description = "Automatic drip coffee maker with 12-cup capacity.", Price = 3499.00m, Stock = 30, CategoryId = 3, ImageUrl = "/images/placeholder.jpg" }
            );
        }
    }
}
