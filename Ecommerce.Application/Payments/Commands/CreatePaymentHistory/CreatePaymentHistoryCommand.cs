using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Payments.Commands.CreatePaymentHistory;

public record CreatePaymentHistoryCommand(Guid OrderId, 
                                          Guid PaymentId,
                                          Guid StatusId,
                                          float TotalPaid,
                                          string? Note) : IRequest<ErrorOr<Created>>;

public class CreatePaymentHistoryCommandHandler(IOrderRepository orderRepository,
                                                IPaymentRepository paymentRepository,
                                                IStatusRepository statusRepository,
                                                IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePaymentHistoryCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreatePaymentHistoryCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetOrderById(request.OrderId, cancellationToken);

        if (order == null)
            return DomainErrors.NotFound("Order", request.OrderId);

        var payment = await paymentRepository
                                    .GetPaymentById(request.PaymentId, cancellationToken);

        if (payment == null)
            return DomainErrors.NotFound("Payment", request.PaymentId);

        var status = await statusRepository.GetStatusById(request.StatusId, cancellationToken);

        if (status == null)
            return DomainErrors.NotFound("Status", request.StatusId);

        var paymentHistory = new PaymentStatusHistory
        {
            Id = Guid.NewGuid(),
            PaymentId = request.PaymentId,
            StatusId = request.StatusId,
            Value = request.TotalPaid,
            Note = request.Note,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await paymentRepository.AddPaymentHistory(paymentHistory, cancellationToken);
        await paymentRepository.UpdatePayment(request.PaymentId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}