namespace Ecommerce.Domain.Entities;

internal class Seller
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
