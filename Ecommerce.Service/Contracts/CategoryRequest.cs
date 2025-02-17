namespace Ecommerce.Service.Contracts
{
    public class CreateCategoryRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
    
    public class UpdateCategoryRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
