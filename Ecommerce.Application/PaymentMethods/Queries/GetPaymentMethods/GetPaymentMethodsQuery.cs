using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.PaymentMethods.Queries.GetPaymentMethods;

public record GetPaymentMethodsQuery() : IRequest<ErrorOr<List<PaymentMethod?>>>;

public class GetPaymentMethodsQueryHandler(IPaymentMethodRepository repository) : IRequestHandler<GetPaymentMethodsQuery, ErrorOr<List<PaymentMethod?>>>
{
    public async Task<ErrorOr<List<PaymentMethod?>>> Handle(GetPaymentMethodsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllPaymentMethod(cancellationToken); 
    }
}
