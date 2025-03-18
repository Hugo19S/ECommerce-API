using FluentValidation;

namespace Ecommerce.Application.Makers.Queries.GetMaker;

public class GetMakerQueryValidator : AbstractValidator<GetMakerQuery>
{
    public GetMakerQueryValidator()
    {
        RuleFor(x => x.MakerId).NotEmpty().WithMessage("Maker ID is required.");
    }
}
