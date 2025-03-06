namespace Ecommerce.Domain.Common;

public class ProductCreateRequest
{
    public Guid CreatedBy { get; set; }
    public Guid SubCategoryId { get; set; }
    public Guid MakerId { get; set; }
    public Guid SellerId { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public string Sku { get; set; }
    public string? Description { get; set; }
    public string? Model { get; set; }
    public List<string> Images { get; set; }
}

public class ProductUpdateRequest
{
    public Guid UpdatedBy { get; set; }
    public Guid SubCategoryId { get; set; }
    public Guid MakerId { get; set; }
    public Guid SellerId { get; set; }
    public string Name { get; set; }
    public string Sku { get; set; }
    public bool IsActive { get; set; }
    public float Price { get; set; }
    public float Discount { get; set; }
    public string? Description { get; set; }
    public string? Model { get; set; }
    public List<string> Images { get; set; }
}
