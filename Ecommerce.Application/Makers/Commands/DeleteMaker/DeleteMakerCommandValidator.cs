using FluentValidation;

namespace Ecommerce.Application.Makers.Commands.DeleteMaker;

public class DeleteMakerCommandValidator : AbstractValidator<DeleteMakerCommand>
{
    public DeleteMakerCommandValidator()
    {
        RuleFor(x => x.MakerId).NotEmpty().WithMessage("Maker ID is required.");
    }
}
