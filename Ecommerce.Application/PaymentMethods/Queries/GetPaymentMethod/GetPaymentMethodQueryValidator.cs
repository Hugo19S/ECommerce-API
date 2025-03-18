using FluentValidation;

namespace Ecommerce.Application.PaymentMethods.Queries.GetPaymentMethod;

public class GetPaymentMethodQueryValidator : AbstractValidator<GetPaymentMethodQuery>
{
    public GetPaymentMethodQueryValidator()
    {
        RuleFor(x => x.PaymentMethodId).NotEmpty().WithMessage("Payment Mathod ID is required.");
    }
}
