using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoeStore.API.Models;

namespace ShoeStore.API.Data
{
public class ShoeStoreContext : DbContext
{
public ShoeStoreContext(DbContextOptions<ShoeStoreContext> options)
: base(options)
{
}

public DbSet<Product> Products { get; set; }
public DbSet<Category> Categories { get; set; }
public DbSet<Review> Reviews { get; set; }
public DbSet<User> Users { get; set; } 

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
base.OnModelCreating(modelBuilder);

// Configure entity relationships and constraints here
modelBuilder.Entity<Product>()
.HasOne(p => p.Category)
.WithMany(c => c.Products)
.HasForeignKey(p => p.CategoryId);

modelBuilder.Entity<Review>()
.HasOne(r => r.Product)
.WithMany(p => p.Reviews)
.HasForeignKey(r => r.ProductId);


// Seed data for Category
modelBuilder.Entity<Category>().HasData(
new Category { Id = 1, Name = "Men" },
new Category { Id = 2, Name = "Women" },
new Category { Id = 3, Name = "Kids" }
);

// Seed data for Product
modelBuilder.Entity<Product>().HasData(
new Product { Id = 1, Name = "Basas Day Slide - Slip On", Price = 100, Currency = "USD", ImageUrl = "/images/1.jpg", Description = "Comfortable running shoes", CategoryId = 1 },
new Product { Id = 2, Name = "Urbas Love+ 24", Price = 50, Currency = "USD", ImageUrl = "/images/2.jpg", Description = "Stylish sandals", CategoryId = 1 },
new Product { Id = 3, Name = "Vintas Public 2000s", Price = 30, Currency = "USD", ImageUrl = "/images/3.jpg", Description = "Durable sneakers", CategoryId = 1 },
new Product { Id = 4, Name = "Ananas Global Goal", Price = 100, Currency = "USD", ImageUrl = "/images/4.jpg", Description = "Comfortable running shoes", CategoryId = 2 },
new Product { Id = 5, Name = "Vintas Vivu - Low Top", Price = 50, Currency = "USD", ImageUrl = "/images/5.jpg", Description = "Stylish sandals", CategoryId = 2 },
new Product { Id = 6, Name = "Vintas Nauda EXT", Price = 30, Currency = "USD", ImageUrl = "/images/6.jpg", Description = "Durable sneakers", CategoryId = 2 },
new Product { Id = 7, Name = "Graphic Tee", Price = 100, Currency = "USD", ImageUrl = "/images/7.jpg", Description = "Comfortable running shoes", CategoryId = 3 },
new Product { Id = 8, Name = "Pattas Tomo - Low Top", Price = 50, Currency = "USD", ImageUrl = "/images/8.jpg", Description = "Stylish sandals", CategoryId = 3 },
new Product { Id = 9, Name = "Track 6 2.Blues", Price = 30, Currency = "USD", ImageUrl = "/images/9.jpg", Description = "Durable sneakers", CategoryId = 3 },
new Product { Id = 10, Name = "Slip On", Price = 100, Currency = "USD", ImageUrl = "/images/10.jpg", Description = "Comfortable running shoes", CategoryId = 1 },
new Product { Id = 11, Name = "High top", Price = 50, Currency = "USD", ImageUrl = "/images/11.jpg", Description = "Stylish sandals", CategoryId = 1 },
new Product { Id = 12, Name = "Vansic 2000s", Price = 30, Currency = "USD", ImageUrl = "/images/12.jpg", Description = "Durable sneakers", CategoryId = 1 }
);

// Seed data for User
modelBuilder.Entity<User>().HasData(
new User { Id = 1, Username = "ngaltq",Email ="1@testmail.com", Password = "123456" },
new User { Id = 2, Username = "quantd",Email ="2@testmail.com", Password = "123456" }
);

// Seed data for Review
modelBuilder.Entity<Review>().HasData(
new Review { Id = 1,Content = "Great shoes!" ,Rating = 5, ProductId = 1  },
new Review { Id = 2,Content = "Very comfortable." ,Rating = 5, ProductId = 1  }
);


}
}
}
