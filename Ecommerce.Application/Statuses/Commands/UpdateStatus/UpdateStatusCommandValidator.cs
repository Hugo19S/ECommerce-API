using FluentValidation;

namespace Ecommerce.Application.Statuses.Commands.UpdateStatus;

public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
{
    public UpdateStatusCommandValidator()
    {
        RuleFor(x => x.StatusId).NotEmpty().WithMessage("Status ID is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Type).NotEmpty().WithMessage("Type is required.");
    }
}
