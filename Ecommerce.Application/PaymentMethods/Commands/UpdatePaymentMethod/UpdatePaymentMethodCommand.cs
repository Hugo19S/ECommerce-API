using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
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
            return DomainErrors.NotFound("PaymentMethod", request.PaymentMethodId);

        var paymentMethodWithSameName = await repository.GetPaymentMethodByName(request.Name, cancellationToken);

        if (paymentMethodWithSameName != null)
            return DomainErrors.Conflict("PaymentMethod");

        await repository.UpdatePaymentMethod(request.PaymentMethodId, request.Name, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
