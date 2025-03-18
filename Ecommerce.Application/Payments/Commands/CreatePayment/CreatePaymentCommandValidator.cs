using FluentValidation;

namespace Ecommerce.Application.Payments.Commands.CreatePayment;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
        RuleFor(x => x.PaymentMethodId).NotEmpty().WithMessage("Payment ID is required.");
        RuleFor(x => x.StatusId).NotEmpty().WithMessage("Status ID is required.");
        RuleFor(x => x.TotalPayable).NotEmpty().WithMessage("Total payable is required.");
        RuleFor(x => x.TotalPaid).NotEmpty().WithMessage("Total paid is required.");
        RuleFor(x => x.InstallmentsNumber).NotEmpty().WithMessage("Installments Number is required.");
    }
}
