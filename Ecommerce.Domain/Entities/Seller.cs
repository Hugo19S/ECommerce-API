namespace Ecommerce.Domain.Entities;

public class Seller
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
