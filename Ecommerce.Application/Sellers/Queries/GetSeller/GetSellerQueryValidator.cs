using FluentValidation;

namespace Ecommerce.Application.Sellers.Queries.GetSeller;

public class GetSellerQueryValidator : AbstractValidator<GetSellerQuery>
{
    public GetSellerQueryValidator()
    {
        RuleFor(x => x.SellerId).NotEmpty().WithMessage("Seller ID is required.");
    }
}
