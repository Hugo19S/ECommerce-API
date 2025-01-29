namespace Ecommerce.Domain.Entities;

internal class ProductDiscount
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid CreatedBy { get; set; }
    public float Discount { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Product Product { get; set; }
    public User Creator { get; set; }
}
