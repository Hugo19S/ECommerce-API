namespace Ecommerce.Domain.Entities;

internal class Status
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string? Description { get; set; }
}
