namespace Ecommerce.Service.Contracts
{
    public class CreateStatusRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
    }

        public class UpdateStatusRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string? Description { get; set; }
    }
}
