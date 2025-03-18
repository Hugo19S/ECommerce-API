using FluentValidation;

namespace Ecommerce.Application.Sellers.Commands.DeleteSeller;

public class DeleteSellerCommandValdator : AbstractValidator<DeleteSellerCommand>
{
    public DeleteSellerCommandValdator()
    {
        RuleFor(x => x.SellerId).NotEmpty().WithMessage("Seller ID is required.");
    }
}
