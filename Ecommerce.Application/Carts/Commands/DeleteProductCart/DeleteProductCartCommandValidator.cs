using FluentValidation;

namespace Ecommerce.Application.Carts.Commands.DeleteProductCart;

public class DeleteProductCartCommandValidator : AbstractValidator<DeleteProductCartCommand>
{
    public DeleteProductCartCommandValidator()
    {
        RuleFor(x => x.ProductId)
    .NotEmpty().WithMessage("Product ID is required.");

        RuleFor(x => x.CartId)
            .NotEmpty().WithMessage("Cart ID is required.");
    }
}
