using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

public interface IPaymentRepository
{
    Task<ErrorOr<Created>> AddPayment(Guid orderId,
                                      Guid paymentMethodId,
                                      Guid statusId,
                                      float totalPaid,
                                      CancellationToken cancellationToken);
    Task<ErrorOr<Payment>> GetPaymentById(Guid paymentId, CancellationToken cancellationToken);
    Task<List<Payment>> GetAllPayment(Guid paymentId, Guid orderId, CancellationToken cancellationToken);
    Task<List<Updated>> UpdatePayment(Guid paymentId,
                                      Guid statusId,
                                      float value,
                                      string? note,
                                      CancellationToken cancellationToken);
}
