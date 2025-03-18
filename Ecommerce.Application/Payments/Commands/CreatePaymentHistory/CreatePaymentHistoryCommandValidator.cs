using FluentValidation;

namespace Ecommerce.Application.Payments.Commands.CreatePaymentHistory;

public class CreatePaymentHistoryCommandValidator : AbstractValidator<CreatePaymentHistoryCommand>
{
    public CreatePaymentHistoryCommandValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
        RuleFor(x => x.StatusId).NotEmpty().WithMessage("Status ID is required.");
        RuleFor(x => x.PaymentId).NotEmpty().WithMessage("Payment ID is required.");
        RuleFor(x => x.TotalPaid).NotEmpty().WithMessage("Total paid is required.");
    }
}
