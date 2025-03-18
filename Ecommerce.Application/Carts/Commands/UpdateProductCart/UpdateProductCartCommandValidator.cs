using FluentValidation;

namespace Ecommerce.Application.Carts.Commands.UpdateProductCart;

public class UpdateProductCartCommandValidator : AbstractValidator<UpdateProductCartCommand>
{
    public UpdateProductCartCommandValidator()
    {
        RuleFor(x => x.ProductId)
    .NotEmpty().WithMessage("Product ID is required.");

        RuleFor(x => x.CartId)
            .NotEmpty().WithMessage("Cart ID is required.");

        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required.")
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}
