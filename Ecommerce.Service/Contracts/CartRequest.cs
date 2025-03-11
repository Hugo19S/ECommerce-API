namespace Ecommerce.Service.Contracts;

public class CartProductRequest
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

public class CartUpdateProductRequest
{
    public int Quantity { get; set; }
}
