using FluentValidation;

namespace Ecommerce.Application.SubCategories.Queries.GetSubCategory;

public class GetSubCategoryQueryValidator : AbstractValidator<GetSubCategoryQuery>
{
    public GetSubCategoryQueryValidator()
    {
        RuleFor(x => x.SubCategoryId).NotEmpty().WithMessage("Subcategory ID is required.");
    }
}
