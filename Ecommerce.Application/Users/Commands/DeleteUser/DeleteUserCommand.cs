using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Users.Commands.DeleteUser;

public record DeleteUserCommand(Guid UserId) : IRequest<ErrorOr<Deleted>>;

public class DeleteUserCommandHandler(IUserRepository userRepository) : IRequestHandler<DeleteUserCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userExist = await userRepository.GetUserById(request.UserId, cancellationToken);

        if (userExist == null)
            return DomainErrors.NotFound("User", request.UserId);

        return await userRepository.DeleteUser(request.UserId, cancellationToken);
    }
}
