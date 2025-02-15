﻿using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.PaymentMethods.Commands.DeletePaymentMethod;

public record DeletePaymentMethodCommand(Guid PaymentMethodId) : IRequest<ErrorOr<Deleted>>;

public class DeletePaymentMethodCommandHandler(IPaymentMethodRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeletePaymentMethodCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var paymentMethodExist = await repository.GetPaymentMethodById(request.PaymentMethodId, cancellationToken);
        
        if (paymentMethodExist == null) 
        {
            return Error.NotFound("PaymentMethod.NotFound", $"PaymentMethod with id {request.PaymentMethodId} not found.");
        }

        await repository.DeletePaymentMethod(request.PaymentMethodId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Deleted();
    }
}
