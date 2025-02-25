namespace Ecommerce.Service.Contracts;

public class CreateSubCategoryRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateSubCategoryRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
}

public class SubCategoryResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}