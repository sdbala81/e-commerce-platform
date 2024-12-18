using Ecommerce.Ordering.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Ordering;

public static class OrderEndpoints
{
    public static RouteGroupBuilder MapOrderEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/orders");

        // GET: /customers
        group.MapGet("/", async (ApplicationDbContext db) =>
            await db.Orders.ToListAsync());

        // GET: /customers/{id}
        group.MapGet("/{id:int}", async (int id, ApplicationDbContext db) =>
            await db.Orders.FindAsync(id) is { } customer
                ? Results.Ok(customer)
                : Results.NotFound());

        // POST: /customers
        group.MapPost("/", async (Order customer, ApplicationDbContext db) =>
        {
            db.Orders.Add(customer);
            await db.SaveChangesAsync();
            return Results.Created($"/customers/{customer.Id}", customer);
        });

        // PUT: /customers/{id}
        group.MapPut("/{id:int}", async (int id, Order updatedOrder, ApplicationDbContext db) =>
        {
            var customer = await db.Orders.FindAsync(id);
            if (customer is null) return Results.NotFound();

            customer.CustomerId = updatedOrder.CustomerId;
            customer.OrderItems = updatedOrder.OrderItems;
            customer.ShippingAddress = updatedOrder.ShippingAddress;
            customer.OrderDate = updatedOrder.OrderDate;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        // DELETE: /customers/{id}
        group.MapDelete("/{id:int}", async (int id, ApplicationDbContext db) =>
        {
            var customer = await db.Orders.FindAsync(id);
            if (customer is null) return Results.NotFound();

            db.Orders.Remove(customer);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        return group;
    }
}