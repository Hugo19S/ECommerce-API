using Ecommerce.Domain.Common;

namespace Ecommerce.Service.Contracts;

public class CreateOrderRequest
{
    public float Value { get; set; }
    public List<OrderItemsRequest> OrderItems { get; set; }
}

public class UpdateOrderRequest
{
    public float Value { get; set; }
}

public class CreateOrderHistoryRequest
{
    public string Note { get; set; }
}

public class OrderResponse
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public float Total { get; set; }
    public DateTimeOffset CreateAt { get; set; }
}

public class OrderHistoryResponse
{
    public Guid Id { get; set; }
    public Guid OrderId { get; set; }
    public Guid StatusId { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
