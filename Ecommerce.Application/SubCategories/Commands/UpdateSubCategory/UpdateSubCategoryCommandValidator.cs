using FluentValidation;

namespace Ecommerce.Application.SubCategories.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandValidator : AbstractValidator<UpdateSubCategoryCommand>
{
    public UpdateSubCategoryCommandValidator()
    {
        RuleFor(x => x.SubCategoryId).NotEmpty().WithMessage("Subcategory ID is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
