namespace Ecommerce.Domain.Entities;

public class Product
{
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid SubCategoryId { get; set; }
    public Guid MakerId { get; set; }
    public Guid SellerId { get; set; }
    public string Name { get; set; }
    public string Sku { get; set; }
    public string? Description { get; set; }
    public string? Model { get; set; }
    public bool IsActive { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public User Creator { get; set; }
    public SubCategory SubCategory { get; set; }
    public Maker Maker { get; set; }
    public Seller Seller { get; set; }
}
