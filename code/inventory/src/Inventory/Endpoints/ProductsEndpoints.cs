using Ecommerce.Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Inventory.Endpoints;

public static class ProductEndpoints
{
    public static RouteGroupBuilder MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/products");

        group.MapGet("/", async (ApplicationDbContext db) =>
            await db.Products.Include(p => p.Category).ToListAsync());

        group.MapGet("/{id:int}", async (int id, ApplicationDbContext db) =>
            await db.Products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id) is Product product
                ? Results.Ok(product)
                : Results.NotFound());

        group.MapPost("/", async (Product product, ApplicationDbContext db) =>
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return Results.Created($"/products/{product.Id}", product);
        });

        group.MapPut("/{id:int}", async (int id, Product updatedProduct, ApplicationDbContext db) =>
        {
            var product = await db.Products.FindAsync(id);
            if (product is null) return Results.NotFound();

            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.CategoryId = updatedProduct.CategoryId;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, ApplicationDbContext db) =>
        {
            var product = await db.Products.FindAsync(id);
            if (product is null) return Results.NotFound();

            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        return group;
    }
}