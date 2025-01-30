namespace Ecommerce.Domain.Entities;

public class PaymentMethod
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}
