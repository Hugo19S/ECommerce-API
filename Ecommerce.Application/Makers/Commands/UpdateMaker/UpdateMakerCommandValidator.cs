using FluentValidation;

namespace Ecommerce.Application.Makers.Commands.UpdateMaker;

public class UpdateMakerCommandValidator : AbstractValidator<UpdateMakerCommand>
{
    public UpdateMakerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.MakerId).NotEmpty().WithMessage("Maker ID is required.");
    }
}
