using FluentValidation;

namespace Ecommerce.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
        RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
        //RuleFor(x => x.Address).NotEmpty().WithMessage("Address is required.");
    }
}
