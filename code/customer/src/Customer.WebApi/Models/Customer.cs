namespace Ecommerce.Customer.WebApi.Models;

public class Customer
{
    public int Id { get; set; } // Primary key
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
}
