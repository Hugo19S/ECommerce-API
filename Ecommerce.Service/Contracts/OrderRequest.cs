using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;

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
    public float Total { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public List<OrderItemsResponse> Items { get; set; }
    public List<OrderHistoryResponse> StatusHistory { get; set; }
}

public class OrderHistoryResponse
{
    public Guid Id { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Status Status { get; set; }
}

public class OrderItemsResponse
{
    public Guid Id { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; }
}
