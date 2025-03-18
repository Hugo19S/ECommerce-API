using FluentValidation;

namespace Ecommerce.Application.PaymentMethods.Commands.UpdatePaymentMethod;

public class UpdatePaymentMethodCommandValidator : AbstractValidator<UpdatePaymentMethodCommand>
{
    public UpdatePaymentMethodCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name ID is required.");
        RuleFor(x => x.PaymentMethodId).NotEmpty().WithMessage("Payment Method ID is required.");
    }
}
