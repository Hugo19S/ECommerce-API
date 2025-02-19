namespace Ecommerce.Service.Contracts
{
    public class CreateSellerRequest
    {
        public string Name { get; set; }
    }
    
    public class UpdateSellerRequest
    {
        public string Name { get; set; }
    }
    
    public class SellerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
