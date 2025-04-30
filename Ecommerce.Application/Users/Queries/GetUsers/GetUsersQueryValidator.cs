using FluentValidation;

namespace Ecommerce.Application.Users.Queries.GetUsers;

public class GetUsersQueryValidator : AbstractValidator<GetUsersQuery>
{
    public GetUsersQueryValidator()
    {
        RuleFor(x => x.Limit)
        .NotEmpty().WithMessage("Limit is required.")
        .GreaterThan(0).WithMessage("Limit must be greater than 0.")
        .LessThanOrEqualTo(100).WithMessage("Limit must be 100 or less.");

        RuleFor(x => x.Page)
        .NotEmpty().WithMessage("Page number is required.")
        .GreaterThan(0).WithMessage("Page number must be greater than 0.");
    }
}
