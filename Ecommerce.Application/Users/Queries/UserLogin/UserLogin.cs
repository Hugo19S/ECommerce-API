using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.AppSettings;
using Ecommerce.Domain.Common;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Options;

namespace Ecommerce.Application.Users.Queries.UserLogin;

public record UserLogin(string Email, string Password) : IRequest<ErrorOr<LoginDto>>;

public class UserLoginHandler(IUserRepository userRepository, IOptions<KeycloakSettings> options)
    : IRequestHandler<UserLogin, ErrorOr<LoginDto>>
{
    public async Task<ErrorOr<LoginDto>> Handle(UserLogin request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmail(request.Email, cancellationToken);

        if (user == null)
            return DomainErrors.Generic();

        var http = new HttpClient();
        var keycloakSettings = new KeycloakSettings()
        {
            Username = request.Email,
            Password = request.Password,
            TokenEndpoint = options.Value.TokenEndpoint
        };

        // 2. Gerar token JWT
        var token = await userRepository.GetUserKeycloakToken(http, keycloakSettings, cancellationToken);

        if (token.IsError)
        {
            return token.Errors;
        }

        return new LoginDto
        {
            ToKen = token.Value,
            User = user
        };
    }
}