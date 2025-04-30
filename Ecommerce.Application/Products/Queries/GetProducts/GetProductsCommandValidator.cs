using FluentValidation;

namespace Ecommerce.Application.Products.Queries.GetProducts;

public class GetProductsCommandValidator : AbstractValidator<GetProductsCommand>
{
    public GetProductsCommandValidator()
    {
        RuleFor(x => x.Limit)
            .NotEmpty().WithMessage("Limit is required.")
            .GreaterThan(0).WithMessage("Limit must be greater than 0.")
            .LessThanOrEqualTo(100).WithMessage("Limit must be 100 or less.");

        RuleFor(x => x.Page)
            .NotEmpty().WithMessage("Page number is required.")
            .GreaterThan(0).WithMessage("Page number must be greater than 0.");
    }
}
