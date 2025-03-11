using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string FirstName,
                             string LastName,
                             string Email,
                             string Password,
                             string? PhoneNumber,
                             string Address) : IRequest<ErrorOr<Created>>;

public class CreateUserCommandHandler(IUserRepository userRepository,
                                      IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateUserCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmail(request.Email, cancellationToken);

        if (user != null)
            return DomainErrors.Conflict("User");

        var role = await userRepository.GetRole("Customer", cancellationToken);

        var createUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            UserRoleId = role!.Id,
            CreatedAt = DateTime.UtcNow
        };

        var cart = new Cart
        {
            Id= Guid.NewGuid(),
            UserId = createUser.Id
        };

        await userRepository.AddUser(createUser, cancellationToken);
        await userRepository.CreateUserCart(cart, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new Created();
    }
}
