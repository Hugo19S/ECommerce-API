using FluentValidation;

namespace Ecommerce.Application.Categories.Commands.PatchCategory;

public class PatchCategoryCommandValidator : AbstractValidator<PatchCategoryCommand>
{
    public PatchCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required.");
        RuleFor(x => x.JsonPatch).NotEmpty().WithMessage("You need to indicate an operation.");
    }
}
