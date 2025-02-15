using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.PaymentMethods.Commands.CreatePaymentMethod;

public record CreatePaymentMethodCommand(string Name) : IRequest<ErrorOr<Created>>;

public class CreatePaymentMethodCommandHandler(IPaymentMethodRepository repository,IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePaymentMethodCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var paymentMethodExist = await repository.GetPaymentMethodByName(request.Name, cancellationToken);

        if (paymentMethodExist != null) 
        {
            return Error.Conflict("PaymentMethod.Conflict", "There's already a payment method with the same name!");
        }

        var newPaymentMethod = new PaymentMethod
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedAt = DateTimeOffset.UtcNow,
        };

        await repository.AddPaymentMethod(newPaymentMethod, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
