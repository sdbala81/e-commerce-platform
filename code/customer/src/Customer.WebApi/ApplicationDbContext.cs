using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Customer.WebApi;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Models.Customer> Customers { get; set; }
}