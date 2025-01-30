namespace Ecommerce.Domain.Entities;

public class OrderItems
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}
