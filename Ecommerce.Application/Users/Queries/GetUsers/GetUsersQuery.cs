using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Users.Queries.GetUsers;

public record GetUsersQuery() : IRequest<ErrorOr<List<User>>>;

public record GetUsersQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUsersQuery, ErrorOr<List<User>>>
{
    public async Task<ErrorOr<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await userRepository.GetAllUser(cancellationToken);
    }
}
