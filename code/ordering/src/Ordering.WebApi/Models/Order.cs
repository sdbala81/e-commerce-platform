namespace Ecommerce.Ordering.Models;

public class Order
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
    public DateTime OrderDate { get; set; }
    public Address ShippingAddress { get; set; }
}