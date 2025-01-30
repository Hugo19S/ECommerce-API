namespace Ecommerce.Domain.Entities;

public class PaymentStatusHistory
{
    public Guid Id { get; set; }
    public Guid PaymentId { get; set; }
    public Guid StatusId { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public Payment Payment { get; set; }
    public Status Status { get; set; }

}
