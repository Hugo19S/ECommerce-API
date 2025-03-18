using FluentValidation;

namespace Ecommerce.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Product.CreatedBy).NotEmpty().WithMessage("User (Creator) ID is required.");
        RuleFor(x => x.Product.SubCategoryId).NotEmpty().WithMessage("Subcategory ID is required.");
        RuleFor(x => x.Product.MakerId).NotEmpty().WithMessage("Maker ID is required.");
        RuleFor(x => x.Product.SellerId).NotEmpty().WithMessage("Seller ID is required.");
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Product.Sku).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Product.Images).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Product.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}
