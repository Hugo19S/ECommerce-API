using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Common;

public class OrderDto
{
    public Guid Id { get; set; }
    public float Total { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public List<OrderItems> Items { get; set; }
    public List<OrderStatusHistory> StatusHistory { get; set; }
}
