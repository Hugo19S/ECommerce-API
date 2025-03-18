using FluentValidation;

namespace Ecommerce.Application.Carts.Queries.GetPrudctsCart;

public class GetPrudctsCartQueryValidator : AbstractValidator<GetPrudctsCartQuery>
{
    public GetPrudctsCartQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.");
    }
}
