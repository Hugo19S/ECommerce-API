using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IPaymentRepository
{
    Task AddPayment(Payment payment, CancellationToken cancellationToken);
    Task AddPaymentHistory(PaymentStatusHistory paymentHistory,  CancellationToken cancellationToken);
    Task<Payment?> GetPaymentById(Guid paymentId, CancellationToken cancellationToken);
    Task<PaymentDto?> GetPaymentByOrder(Guid orderId, CancellationToken cancellationToken);
    Task UpdatePayment(Guid paymentId, CancellationToken cancellationToken);
}
