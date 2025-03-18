using FluentValidation;

namespace Ecommerce.Application.PaymentMethods.Commands.DeletePaymentMethod;

public class DeletePaymentMethodCommandValidator : AbstractValidator<DeletePaymentMethodCommand>
{
    public DeletePaymentMethodCommandValidator()
    {
        RuleFor(x => x.PaymentMethodId).NotEmpty().WithMessage("Payment Method ID is required.");
    }
}
