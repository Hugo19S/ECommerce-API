using FluentValidation;

namespace Ecommerce.Application.SubCategories.Queries.GetSubCategories;

public class GetSubCategoriesQueryValidator : AbstractValidator<GetSubCategoriesQuery>
{
    public GetSubCategoriesQueryValidator()
    {
        RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Category ID is required.");
    }
}
