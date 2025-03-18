using FluentValidation;

namespace Ecommerce.Application.Sellers.Queries.GetSeller;

public class GetSellerCommandValidator : AbstractValidator<GetSellerCommand>
{
    public GetSellerCommandValidator()
    {
        RuleFor(x => x.SellerId).NotEmpty().WithMessage("Seller ID is required.");
    }
}
