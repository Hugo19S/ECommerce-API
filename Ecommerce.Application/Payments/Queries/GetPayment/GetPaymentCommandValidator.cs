using FluentValidation;

namespace Ecommerce.Application.Payments.Queries.GetPayment;

public class GetPaymentCommandValidator : AbstractValidator<GetPaymentCommand>
{
    public GetPaymentCommandValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
    }
}
