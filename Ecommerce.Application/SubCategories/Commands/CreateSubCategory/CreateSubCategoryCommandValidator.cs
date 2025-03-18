using FluentValidation;

namespace Ecommerce.Application.SubCategories.Commands.CreateSubCategory;

public class CreateSubCategoryCommandValidator : AbstractValidator<CreateSubCategoryCommand>
{
    public CreateSubCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
