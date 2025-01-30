namespace Ecommerce.Domain.Entities;

public class Maker
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}
