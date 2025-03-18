using FluentValidation;

namespace Ecommerce.Application.Orders.Commands.CreateOrderHistory;

public class CreateOrderHistoryCommandValiator : AbstractValidator<CreateOrderHistoryCommand>
{
    public CreateOrderHistoryCommandValiator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
        RuleFor(x => x.StatusId).NotEmpty().WithMessage("Status ID is required.");
    }
}
