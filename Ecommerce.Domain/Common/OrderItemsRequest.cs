namespace Ecommerce.Domain.Common;


public class OrderItemsRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}