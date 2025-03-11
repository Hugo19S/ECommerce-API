namespace Ecommerce.Domain.Common;

public class CartDto
{
    public Guid Id { get; set; }
    public Guid CartId { get; set; }
    public int Quantity { get; set; }
    public List<ProductDto> Product { get; set; }
}
