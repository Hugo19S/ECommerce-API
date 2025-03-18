using FluentValidation;

namespace Ecommerce.Application.Sellers.Commands.CreateSeller;

public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
    }
}
