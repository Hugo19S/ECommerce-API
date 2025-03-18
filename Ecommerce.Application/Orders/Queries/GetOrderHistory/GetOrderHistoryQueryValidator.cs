using FluentValidation;

namespace Ecommerce.Application.Orders.Queries.GetOrderHistory;

public class GetOrderHistoryQueryValidator : AbstractValidator<GetOrderHistoryQuery>
{
    public GetOrderHistoryQueryValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
    }
}
