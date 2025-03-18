using FluentValidation;

namespace Ecommerce.Application.Orders.Queries.GetOrder;

public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
{
    public GetOrderQueryValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("Order ID is required.");
    }
}
