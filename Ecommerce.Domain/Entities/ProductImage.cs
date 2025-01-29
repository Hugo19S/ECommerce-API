namespace Ecommerce.Domain.Entities;

internal class ProductImage
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public string Uri { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public Product Product { get; set; }
}
