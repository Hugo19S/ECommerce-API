using FluentValidation;

namespace Ecommerce.Application.Carts.Commands.CreateProductCart;

public class CreateProductCartCommandValidator : AbstractValidator<CreateProductCartCommand>
{
    public CreateProductCartCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required.");
        RuleFor(x => x.UserId).NotEmpty().WithMessage("User ID is required.");
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Quantity is required.")
            .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
    }
}
