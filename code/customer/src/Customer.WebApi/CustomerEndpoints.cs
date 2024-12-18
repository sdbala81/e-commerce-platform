using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Customer.WebApi;

public static class CustomerEndpoints
{
    public static RouteGroupBuilder MapCustomerEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/customers");

        // GET: /customers
        group.MapGet("/", async (ApplicationDbContext db) =>
            await db.Customers.ToListAsync());

        // GET: /customers/{id}
        group.MapGet("/{id:int}", async (int id, ApplicationDbContext db) =>
            await db.Customers.FindAsync(id) is { } customer
                ? Results.Ok(customer)
                : Results.NotFound());

        // POST: /customers
        group.MapPost("/", async (Models.Customer customer, ApplicationDbContext db) =>
        {
            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return Results.Created($"/customers/{customer.Id}", customer);
        });

        // PUT: /customers/{id}
        group.MapPut("/{id:int}", async (int id, Models.Customer updatedCustomer, ApplicationDbContext db) =>
        {
            var customer = await db.Customers.FindAsync(id);
            if (customer is null) return Results.NotFound();

            customer.FirstName = updatedCustomer.FirstName;
            customer.LastName = updatedCustomer.LastName;
            customer.Email = updatedCustomer.Email;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;

            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        // DELETE: /customers/{id}
        group.MapDelete("/{id:int}", async (int id, ApplicationDbContext db) =>
        {
            var customer = await db.Customers.FindAsync(id);
            if (customer is null) return Results.NotFound();

            db.Customers.Remove(customer);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        return group;
    }
}
