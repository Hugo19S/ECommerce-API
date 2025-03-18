using FluentValidation;

namespace Ecommerce.Application.Orders.Queries.GetUserOrders;

public class GetUserOrdersQueryValidator : AbstractValidator<GetUserOrdersQuery>
{
    public GetUserOrdersQueryValidator()
    {
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
    }
}
