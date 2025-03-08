using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Payments.Queries.GetPayment;

public record GetPaymentCommand(Guid OrderId) : IRequest<ErrorOr<PaymentDto>>;
public class GetPaymentCommandHandler(IPaymentRepository paymentRepository,
                                      IOrderRepository orderRepository)
    : IRequestHandler<GetPaymentCommand, ErrorOr<PaymentDto>>
{
    public async Task<ErrorOr<PaymentDto>> Handle(GetPaymentCommand request, CancellationToken cancellationToken)
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
