namespace Ecommerce.Ordering.Models;

public class OrderItem
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}