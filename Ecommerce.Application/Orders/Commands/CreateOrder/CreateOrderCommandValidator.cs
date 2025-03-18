using FluentValidation;

namespace Ecommerce.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
        RuleFor(x => x.OrderItems).NotEmpty().WithMessage("OrderItems is required.");
        RuleFor(x => x.Value)
            .NotEmpty().WithMessage("Value is required.")
            .GreaterThan(0).WithMessage("Value must be greater than zero.");
    }
}
