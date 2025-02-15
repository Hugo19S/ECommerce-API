using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.PaymentMethods.Commands.UpdatePaymentMethod;

public record UpdatePaymentMethodCommand(Guid PaymentMethodId, string Name) : IRequest<ErrorOr<Updated>>;

public class UpdatePaymentMethodCommandHandler(IPaymentMethodRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdatePaymentMethodCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var paymentMethodExist = await repository.GetPaymentMethodById(request.PaymentMethodId, cancellationToken);

        if (paymentMethodExist == null)
        {
            return Error.NotFound("PaymentMethod.NotFound", $"PaymentMethod with id {request.PaymentMethodId} not found.");
        }

        var paymentMethodWithSameName = await repository.GetPaymentMethodByName(request.Name, cancellationToken);

        if (paymentMethodWithSameName != null)
        {
            return Error.Conflict("PaymentMethod.Conflict", "There's already a payment method with the same name!");
        }

        await repository.UpdatePaymentMethod(request.PaymentMethodId, request.Name, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
