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
                             string Address,
                             Guid UserRoleId) : IRequest<ErrorOr<Created>>;

public class CreateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmail(request.Email, cancellationToken);

        if (user != null)
        {
            return Error.Conflict("User.Conflict", "There's already a user with the same e-mail address!");
        }

        var createUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            UserRoleId = request.UserRoleId,
            CreatedAt = DateTime.UtcNow
        };
        await userRepository.AddUser(createUser, cancellationToken);
        return new Created();
    }
}
