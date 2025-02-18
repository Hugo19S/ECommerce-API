namespace Ecommerce.Service.Contracts
{
    public class CreatePaymentMethodRequest
    {
        public string Name { get; set; }
    }
    
    public class UpdatePaymentMethodRequest
    {
        public string Name { get; set; }
    }
    
    public class PaymentMethodResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
