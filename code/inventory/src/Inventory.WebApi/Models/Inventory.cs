namespace Ecommerce.Inventory.Models;

public class Inventory
{
    public int Id { get; set; }
    public string Location { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new();
}