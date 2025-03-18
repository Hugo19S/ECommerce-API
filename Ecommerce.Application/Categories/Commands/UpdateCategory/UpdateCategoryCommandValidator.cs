using FluentValidation;

namespace Ecommerce.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Cartegory ID is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
