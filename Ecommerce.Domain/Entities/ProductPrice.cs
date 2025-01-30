namespace Ecommerce.Domain.Entities;

public class ProductPrice
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid CreatedBy { get; set; }
    public float Price { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Product Product { get; set; }
    public User Creator { get; set; }
}
