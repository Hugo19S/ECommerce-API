using FluentValidation;

namespace Ecommerce.Application.Sellers.Commands.UpdateSeller;

public class UpdateSellerCommandValidator : AbstractValidator<UpdateSellerCommand>
{
    public UpdateSellerCommandValidator()
    {
        RuleFor(x => x.SellerId).NotEmpty().WithMessage("Seller ID is required.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
