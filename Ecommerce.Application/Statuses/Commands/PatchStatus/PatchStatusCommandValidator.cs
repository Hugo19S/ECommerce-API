using FluentValidation;

namespace Ecommerce.Application.Statuses.Commands.PatchStatus;

public class PatchStatusCommandValidator : AbstractValidator<PatchStatusCommand>
{
    public PatchStatusCommandValidator()
    {
        RuleFor(x => x.StatusId).NotEmpty().WithMessage("Status ID is required.");
        RuleFor(x => x.JsonPatch).NotEmpty().WithMessage("You need to indicate an operation.");
    }
}
