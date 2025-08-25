using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.AppSettings;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace Ecommerce.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string FirstName,
                             string LastName,
                             string Email,
                             string Password,
                             string? PhoneNumber,
                             string? Address) : IRequest<ErrorOr<Created>>;

public class CreateUserCommandHandler(IUserRepository userRepository,
                                      ICartRepository cartRepository,
                                      IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateUserCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        using var http = new HttpClient();
        var user = await userRepository.GetUserByEmail(request.Email, cancellationToken);

        if (user != null)
            return DomainErrors.Conflict("User");

        var createUser = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
            PhoneNumber = request.PhoneNumber,
            Address = request.Address,
            CreatedAt = DateTime.UtcNow
        };

        var cart = new Cart
        {
            Id= Guid.NewGuid(),
            UserId = createUser.Id
        };

        var createUserKeycloak = new UserKeycloak
        {
            Username = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            EmailVerified = true,
            Enabled = true,
            Credentials = 
            [
                new Credential
                {
                    Type = "password",
                    Value = request.Password,
                    Temporary = false
                }

            ]
        };

        await userRepository.AddUser(createUser, cancellationToken);
        await cartRepository.CreateUserCart(cart, cancellationToken);

        var token = await userRepository.GetUserAdminKeycloakToken(http, cancellationToken);
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var userKeycloakId = await userRepository.AddUserToKeycloak(createUserKeycloak, http, cancellationToken);

        await userRepository.AssignRoleToKeycloakUser(userKeycloakId, "Customer", http, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new Created();
    }
}
