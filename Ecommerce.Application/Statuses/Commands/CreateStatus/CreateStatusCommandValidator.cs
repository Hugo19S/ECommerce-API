using FluentValidation;

namespace Ecommerce.Application.Statuses.Commands.CreateStatus;

public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
{
    public CreateStatusCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Status Name is required.");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Status Type is required.");
    }
}
