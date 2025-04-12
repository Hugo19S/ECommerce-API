using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Payments.Queries.GetPayment;

public record GetPaymentQuery(Guid OrderId) : IRequest<ErrorOr<PaymentDto>>;
public class GetPaymentQueryHandler(IPaymentRepository paymentRepository,
                                      IOrderRepository orderRepository)
    : IRequestHandler<GetPaymentQuery, ErrorOr<PaymentDto>>
{
    public async Task<ErrorOr<PaymentDto>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetOrderById(request.OrderId, cancellationToken);

        if (order == null)
            return DomainErrors.NotFound("Order", request.OrderId);

        var payment = await paymentRepository.GetPaymentByOrder(request.OrderId, cancellationToken);

        if (payment is null)
            return DomainErrors.Generic("Order", "Payment");

        return payment;
    }
}
