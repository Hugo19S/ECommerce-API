using ErrorOr;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IPaymentMethodRepository
{
    Task<ErrorOr<Created>> AddPaymentMethod(string name, CancellationToken cancellationToken);
    Task<ErrorOr<PaymentMethod>> GetPaymentMethodById(Guid paymentMethodId, CancellationToken cancellationToken);
    Task<List<PaymentMethod>> GetAllPaymentMethod(CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdatePaymentMethod(string name, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeletePaymentMethod(Guid paymentMethodId, CancellationToken cancellationToken);
}
