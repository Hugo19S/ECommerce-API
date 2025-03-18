using FluentValidation;

namespace Ecommerce.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product ID is required.");
        RuleFor(x => x.UpdateRequest.UpdatedBy).NotEmpty().WithMessage("User (Updator) ID is required.");
        RuleFor(x => x.UpdateRequest.SubCategoryId).NotEmpty().WithMessage("Subcategory ID is required.");
        RuleFor(x => x.UpdateRequest.MakerId).NotEmpty().WithMessage("Maker ID is required.");
        RuleFor(x => x.UpdateRequest.SellerId).NotEmpty().WithMessage("Seller ID is required.");
        RuleFor(x => x.UpdateRequest.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.UpdateRequest.Sku).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.UpdateRequest.Images).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.UpdateRequest.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
    }
}
