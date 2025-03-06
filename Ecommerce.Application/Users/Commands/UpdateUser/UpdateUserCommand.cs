using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Users.Commands.UpdateUser;

public record UpdateUserCommand(Guid UserId,
                                 string Email,
                                 string PhoneNumber,
                                 string Adrress) : IRequest<ErrorOr<Updated>>;

public class UpdateUserCommandHandler(IUserRepository userRepository)
    : IRequestHandler<UpdateUserCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await userRepository.GetUserById(request.UserId, cancellationToken);

        if (userToUpdate == null)
            return DomainErrors.NotFound("User", request.UserId);

        var userWithSameEmail = await userRepository.GetUserByEmail(request.Email, cancellationToken);

        if (userWithSameEmail != null && userToUpdate != userWithSameEmail)
            return DomainErrors.Conflict("User");

        var userUpdated = await userRepository.UpdateUser(request.UserId,
                                                          request.Email,
                                                          request.PhoneNumber,
                                                          request.Adrress,
                                                          cancellationToken);

        return userUpdated;
    }
}
