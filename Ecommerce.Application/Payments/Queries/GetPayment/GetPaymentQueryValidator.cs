using FluentValidation;

namespace Ecommerce.Application.Payments.Queries.GetPayment;

public class GetPaymentQueryValidator : AbstractValidator<GetPaymentQuery>
{
    public GetPaymentQueryValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
    }
}
