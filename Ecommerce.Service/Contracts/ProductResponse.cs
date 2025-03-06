using Ecommerce.Domain.Common;

namespace Ecommerce.Service.Contracts;

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Sku { get; set; }
    public string? Description { get; set; }
    public string? Model { get; set; }
    public string Seller { get; set; }
    public string Maker { get; set; }
    public string SubCategory { get; set; }
    public bool IsActive { get; set; }
    public float Price { get; set; }
    public float Discount { get; set; }
    public List<ImageDto> Images { get; set; }
}
