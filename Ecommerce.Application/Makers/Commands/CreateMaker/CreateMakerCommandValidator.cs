using FluentValidation;

namespace Ecommerce.Application.Makers.Commands.CreateMaker;

public class CreateMakerCommandValidator : AbstractValidator<CreateMakerCommand>
{
    public CreateMakerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
