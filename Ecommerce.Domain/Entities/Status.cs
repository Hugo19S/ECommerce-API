namespace Ecommerce.Domain.Entities;

public class Status
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string? Description { get; set; }
}
