using Ecommerce.Ordering.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Ordering.WebApi;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
}