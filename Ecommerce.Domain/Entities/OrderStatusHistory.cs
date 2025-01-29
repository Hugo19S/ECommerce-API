namespace Ecommerce.Domain.Entities;

internal class OrderStatusHistory
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid StatusId { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Order Order { get; set; }
    public Status Status { get; set; }
}
