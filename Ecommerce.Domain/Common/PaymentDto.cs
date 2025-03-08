using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Common;

public class PaymentDto
{
    public Guid Id { get; set; }
    public float TotalPayable { get; set; }
    public int InstallmentsNumber { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public List<PaymentStatusHistory> PaymentStatusHistory { get; set; }
}
