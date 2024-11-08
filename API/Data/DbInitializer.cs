// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.DependencyInjection;
// using ShoeStore.API.Models;
// using System;
// using System.Linq;
// using System.Threading.Tasks;

// namespace ShoeStore.API.Data
// {
//     public static class DbInitializer
//     {
//         public static async Task Initialize(IServiceProvider serviceProvider)
//         {
//             using (var context = new ShoeStoreContext(
//             serviceProvider.GetRequiredService<DbContextOptions<ShoeStoreContext>>()))
//             {
//                 // Seed Categories
//                 if (!context.Categories.Any())
//                 {
//                     var categories = new Category[]
//                     {
// new Category { Name = "Men" },
// new Category { Name = "Women" },
// new Category { Name = "Kids" }
//                     };

//                     context.Categories.AddRange(categories);
//                     context.SaveChanges();
//                 }

//                 // Seed Products
//                 if (!context.Products.Any())
//                 {
//                     var categories = context.Categories.ToList();
//                     var products = new Product[]
//                     {
// new Product { Name = "Basas Day Slide - Slip On", Price = 100, Currency = "USD", ImageUrl = "/images/1.jpg", Description = "Comfortable running shoes", CategoryId = categories[0].Id },
// new Product { Name = "Urbas Love+ 24", Price = 50, Currency = "USD", ImageUrl = "/images/2.jpg", Description = "Stylish sandals", CategoryId = categories[0].Id },
// new Product { Name = "Vintas Public 2000s", Price = 30, Currency = "USD", ImageUrl = "/images/3.jpg", Description = "Durable sneakers", CategoryId = categories[0].Id },
// new Product { Name = "Ananas Global Goal", Price = 100, Currency = "USD", ImageUrl = "/images/4.jpg", Description = "Comfortable running shoes", CategoryId = categories[0].Id },
// new Product { Name = "Vintas Nauda EXT", Price = 30, Currency = "USD", ImageUrl = "/images/6.jpg", Description = "Durable sneakers", CategoryId = categories[0].Id },
// new Product { Name = "Graphic Tee", Price = 100, Currency = "USD", ImageUrl = "/images/7.jpg", Description = "Comfortable running shoes", CategoryId = categories[1].Id },
// new Product { Name = "Pattas Tomo - Low Top", Price = 50, Currency = "USD", ImageUrl = "/images/8.jpg", Description = "Stylish sandals", CategoryId = categories[1].Id },
// new Product { Name = "Track 6 2.Blues", Price = 30, Currency = "USD", ImageUrl = "/images/9.jpg", Description = "Durable sneakers", CategoryId = categories[1].Id },
// new Product { Name = "Slip On", Price = 100, Currency = "USD", ImageUrl = "/images/10.jpg", Description = "Comfortable running shoes", CategoryId = categories[2].Id },
// new Product { Name = "High top", Price = 50, Currency = "USD", ImageUrl = "/images/11.jpg", Description = "Stylish sandals", CategoryId = categories[2].Id },
// new Product { Name = "Vansic 2000s", Price = 30, Currency = "USD", ImageUrl = "/images/12.jpg", Description = "Durable sneakers", CategoryId = categories[2].Id }
//                     };

//                     context.Products.AddRange(products);
//                     context.SaveChanges();
//                 }

//                 // Seed Users
//                 var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

//                 if (!context.Users.Any())
//                 {
//                     var adminUser = new ApplicationUser
//                     {
//                         UserName = "admin",
//                         Email = "admin@example.com"
//                     };

//                     await userManager.CreateAsync(adminUser, "Password123!");

//                     var user = new ApplicationUser
//                     {
//                         UserName = "ngaltq",
//                         Email = "ngaltq@example.com"
//                     };

//                     await userManager.CreateAsync(user, "123456!");
//                 }

//                 // Seed Reviews
//                 if (!context.Reviews.Any())
//                 {
//                     var products = context.Products.ToList();
//                     var reviews = new Review[]
//                     {
// new Review { Content = "Great product!", Rating = 5, ProductId = products[0].Id },
// new Review { Content = "Not bad", Rating = 3, ProductId = products[1].Id },
// new Review { Content = "Nice", Rating = 3, ProductId = products[1].Id }
//                     };

//                     context.Reviews.AddRange(reviews);
//                     context.SaveChanges();
//                 }
//             }
//         }
//     }
// }
