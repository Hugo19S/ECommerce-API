using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.PaymentMethods.Queries.GetPaymentMethod;

public record GetPaymentMethodQuery(Guid PaymentMethodId) : IRequest<ErrorOr<PaymentMethod>>;

public class GetPaymentMethodQueryHandler(IPaymentMethodRepository repository)
    : IRequestHandler<GetPaymentMethodQuery, ErrorOr<PaymentMethod>>
{
    public async Task<ErrorOr<PaymentMethod>> Handle(GetPaymentMethodQuery request, CancellationToken cancellationToken)
    {
        var paymentMethod = await repository.GetPaymentMethodById(request.PaymentMethodId, cancellationToken);

        if (paymentMethod == null)
            return DomainErrors.NotFound("PaymentMethod", request.PaymentMethodId);

        return paymentMethod;
    }
}
