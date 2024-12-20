namespace Ecommerce.Customer.WebApi;

public static class CustomerSeed
{

    public static void Seed(ApplicationDbContext db)
    {
        if (db.Customers.Any()) return;
        db.Customers.AddRange(GetInitialCustomers());
        db.SaveChanges();

    }

    private static List<Models.Customer> GetInitialCustomers() =>
    [
        new() { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", PhoneNumber = "1234567890" },
        new() { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", PhoneNumber = "9876543210" }
    ];
}