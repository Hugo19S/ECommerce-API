using FluentValidation;

namespace Ecommerce.Application.Statuses.Queries.GetStatus;

public class GetStatusQueryValidator : AbstractValidator<GetStatusQuery>
{
    public GetStatusQueryValidator()
    {
        RuleFor(x => x.StatusId).NotEmpty().WithMessage("Status ID is required.");
    }
}
