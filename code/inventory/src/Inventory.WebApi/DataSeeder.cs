using Ecommerce.Inventory.WebApi.Models;

namespace Ecommerce.Inventory.WebApi;

public static class DataSeeder
{
    public static void Seed(ApplicationDbContext db)
    {
        if (!db.ProductCategories.Any())
        {
            var categories = new List<ProductCategory>
            {
                new() { Id = 1, Name = "Electronics", Description = "Electronic gadgets" },
                new() { Id = 2, Name = "Clothing", Description = "Apparel and wearables" },
                new() { Id = 3, Name = "Groceries", Description = "Daily essentials" },
                new() { Id = 4, Name = "Books", Description = "Books and magazines" }
            };

            db.ProductCategories.AddRange(categories);

            var products = new List<Product>
            {
                // Electronics
                new()
                {
                    Name = "Smartphone", Description = "High-end smartphone with 128GB storage", Price = 699.99m,
                    CategoryId = 1
                },
                new()
                {
                    Name = "Laptop", Description = "15-inch laptop with 16GB RAM", Price = 1299.99m, CategoryId = 1
                },
                new()
                {
                    Name = "Headphones", Description = "Noise-cancelling over-ear headphones", Price = 199.99m,
                    CategoryId = 1
                },
                new()
                {
                    Name = "Smartwatch", Description = "Fitness tracker with heart rate monitor", Price = 149.99m,
                    CategoryId = 1
                },

                // Clothing
                new() { Name = "T-Shirt", Description = "Cotton t-shirt, unisex", Price = 19.99m, CategoryId = 2 },
                new() { Name = "Jeans", Description = "Slim-fit denim jeans", Price = 49.99m, CategoryId = 2 },
                new()
                {
                    Name = "Jacket", Description = "Water-resistant winter jacket", Price = 99.99m, CategoryId = 2
                },
                new()
                {
                    Name = "Sneakers", Description = "Comfortable running sneakers", Price = 59.99m, CategoryId = 2
                },

                // Groceries
                new() { Name = "Milk", Description = "1 gallon of whole milk", Price = 3.49m, CategoryId = 3 },
                new() { Name = "Bread", Description = "Whole grain bread loaf", Price = 2.99m, CategoryId = 3 },
                new() { Name = "Eggs", Description = "Dozen free-range eggs", Price = 4.49m, CategoryId = 3 },
                new() { Name = "Apples", Description = "1kg of fresh red apples", Price = 3.99m, CategoryId = 3 },

                // Books
                new()
                {
                    Name = "C# Programming", Description = "Comprehensive guide to C# and .NET", Price = 29.99m,
                    CategoryId = 4
                },
                new()
                {
                    Name = "Clean Code", Description = "A Handbook of Agile Software Craftsmanship", Price = 24.99m,
                    CategoryId = 4
                },
                new()
                {
                    Name = "The Pragmatic Programmer", Description = "Your journey to mastery", Price = 27.99m,
                    CategoryId = 4
                },
                new()
                {
                    Name = "Design Patterns", Description = "Elements of Reusable Object-Oriented Software",
                    Price = 32.99m, CategoryId = 4
                }
            };

            db.Products.AddRange(products);
            db.SaveChanges();
        }
    }
}