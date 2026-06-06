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
                new Product { Id = 1, Name = "Wireless Headphones", Description = "High quality Bluetooth headphones with noise cancellation.", Price = 4500.00m, Stock = 50, CategoryId = 1, ImageUrl = "/images/headphones.jpeg" },

                new Product { Id = 2, Name = "Lazy Sofa", Description = "Inflatable sofa seat with foot stool and manual pump now available in colour grey, beige, blue, green, red, pink, purple.", Price = 2700.00m, Stock = 200, CategoryId = 2, ImageUrl = "/images/lazysofa.jpeg" },

                new Product { Id = 3, Name = "Water Dispenser", Description = "Ailyons bottom load water dispenser now available hot and cold. Model; AFK 8848.", Price = 9700.00m, Stock = 30, CategoryId = 3, ImageUrl = "/images/dispenser.jpeg" },

                new Product { Id = 4, Name = "Car back seat bed", Description = "Portable inflatable car back seat bed. Comes with a pump powered through the cigar lighter socket. 3 colours available; blue, grey, beige, black.", Price = 3000.00m, Stock = 30, CategoryId = 2, ImageUrl = "/images/carmart.jpeg" },

                new Product { Id = 5, Name = "3Pc Curtains", Description = "2 Curtains 1.5m each, 1 Sheer 3m, height 2.5m.", Price = 3300.00m, Stock = 30, CategoryId = 2, ImageUrl = "/images/curtains.jpeg" },

                new Product { Id = 6, Name = "Non stick sufuria", Description = "High quality non stick 6in1 cake mould/ baking tins now available. Size: 28,26,24,22,18", Price = 1550.00m, Stock = 30, CategoryId = 3, ImageUrl = "/images/nonstick-sufurias.jpeg" },

                new Product { Id = 7, Name = "Wall hangers", Description = "Rectangular 5in1 metallic bathroom shelf organizer shower caddy set now available.", Price = 1800.00m, Stock = 30, CategoryId = 3, ImageUrl = "/images/wallhangers.jpeg" }
            );
        }
    }
}
