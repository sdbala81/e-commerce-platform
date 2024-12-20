namespace Ecommerce.Inventory.WebApi.Models;

public class ProductCategory
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Product> Products { get; set; } = new();
}