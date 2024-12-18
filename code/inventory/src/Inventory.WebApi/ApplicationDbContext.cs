using Ecommerce.Inventory.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Inventory.WebApi;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Models.Inventory> Inventories { get; set; }
}