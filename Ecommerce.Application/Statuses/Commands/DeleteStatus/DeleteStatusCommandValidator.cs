using FluentValidation;

namespace Ecommerce.Application.Statuses.Commands.DeleteStatus;

public class DeleteStatusCommandValidator : AbstractValidator<DeleteStatusCommand>
{
    public DeleteStatusCommandValidator()
    {
        RuleFor(x => x.StatusId).NotEmpty().WithMessage("Status ID is required.");
    }
}
