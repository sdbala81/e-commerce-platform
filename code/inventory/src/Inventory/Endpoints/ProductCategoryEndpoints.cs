using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Inventory.Endpoints;

public static class ProductCategoryEndpoints
{
    public static RouteGroupBuilder MapProductCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/categories");

        group.MapGet("/", async (ApplicationDbContext db) =>
            await db.ProductCategories.Include(c => c.Products).ToListAsync());

        group.MapGet("/{id:int}", async (int id, ApplicationDbContext db) =>
            await db.ProductCategories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id) is { } category
                ? Results.Ok(category)
                : Results.NotFound());

        return group;
    }
}