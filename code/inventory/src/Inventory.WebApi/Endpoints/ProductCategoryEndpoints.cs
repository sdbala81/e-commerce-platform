using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Inventory.Endpoints;

public static class ProductCategoryEndpoints
{
    public static RouteGroupBuilder MapProductCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/categories");

        group.MapGet("/", async (ApplicationDbContext db) =>
            await db.ProductCategories.ToListAsync());

        group.MapGet("/{id:int}", async (int id, ApplicationDbContext db) =>
            await db.ProductCategories.FirstOrDefaultAsync(c => c.Id == id) is { } category
                ? Results.Ok(category)
                : Results.NotFound());

        group.MapGet("/{id:int}/products", async (int id, ApplicationDbContext db) =>
            await db.ProductCategories.Include(productCategory => productCategory.Products)
                .FirstOrDefaultAsync(productCategory => productCategory.Id == id) is { } category
                ? Results.Ok(category)
                : Results.NotFound());

        return group;
    }
}