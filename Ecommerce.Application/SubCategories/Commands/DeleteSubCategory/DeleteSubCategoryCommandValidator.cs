using FluentValidation;

namespace Ecommerce.Application.SubCategories.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommandValidator : AbstractValidator<DeleteSubCategoryCommand>
{
    public DeleteSubCategoryCommandValidator()
    {
        RuleFor(x => x.SubCategoryId).NotEmpty().WithMessage("Subcategory ID is required.");
    }
}
