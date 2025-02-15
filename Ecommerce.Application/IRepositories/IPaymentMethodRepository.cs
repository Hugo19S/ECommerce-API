using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IPaymentMethodRepository
{
    Task AddPaymentMethod(PaymentMethod paymentMethod, CancellationToken cancellationToken);
    Task<PaymentMethod?> GetPaymentMethodById(Guid paymentMethodId, CancellationToken cancellationToken);
    Task<PaymentMethod?> GetPaymentMethodByName(string name, CancellationToken cancellationToken);
    Task<List<PaymentMethod?>> GetAllPaymentMethod(CancellationToken cancellationToken);
    Task UpdatePaymentMethod(Guid paymentMethodId, string name, CancellationToken cancellationToken);
    Task DeletePaymentMethod(Guid paymentMethodId, CancellationToken cancellationToken);
}
