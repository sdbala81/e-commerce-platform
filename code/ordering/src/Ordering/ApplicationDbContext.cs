using Ecommerce.Ordering.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Ordering;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }
}