using FluentValidation;

namespace Ecommerce.Application.Products.Queries.GetProduct;

public class GetProductCommandValidator : AbstractValidator<GetProductCommand>
{
    public GetProductCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required.");
    }
}
