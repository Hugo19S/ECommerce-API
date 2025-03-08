using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Payments.Commands.CreatePayment;

public record CreatePaymentCommand(Guid OrderId,
                                   Guid PaymentMethodId,
                                   Guid StatusId,
                                   float TotalPayable,
                                   float TotalPaid,
                                   string? Note,
                                   int InstallmentsNumber) : IRequest<ErrorOr<Created>>;

public class CreatePaymentCommandHandler(IOrderRepository orderRepository,
                                         IPaymentMethodRepository paymentMethodRepository,
                                         IPaymentRepository paymentRepository,
                                         IStatusRepository statusRepository,
                                         IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePaymentCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetOrderById(request.OrderId, cancellationToken);

        if (order == null)
            return DomainErrors.NotFound("Order", request.OrderId);

        var paymentMethod = await paymentMethodRepository
                                    .GetPaymentMethodById(request.PaymentMethodId, cancellationToken);

        if (paymentMethod == null)
            return DomainErrors.NotFound("PaymentMethod", request.PaymentMethodId);

        var status = await statusRepository.GetStatusById(request.StatusId, cancellationToken);

        if (status == null)
            return DomainErrors.NotFound("Status", request.StatusId);

        var paymentId = Guid.NewGuid();

        var payment = new Payment
        {
            Id = paymentId,
            OrderId = request.OrderId,
            PaymentMethodId = request.PaymentMethodId,
            TotalPayable = request.TotalPayable,
            InstallmentsNumber = request.InstallmentsNumber,
            CreatedAt = DateTimeOffset.UtcNow,
        };

        var paymentHistory = new PaymentStatusHistory
        {
            Id = Guid.NewGuid(),
            PaymentId = paymentId,
            StatusId = request.StatusId,
            Value = request.TotalPaid,
            Note = request.Note,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await paymentRepository.AddPayment(payment, cancellationToken);
        await paymentRepository.AddPaymentHistory(paymentHistory, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
