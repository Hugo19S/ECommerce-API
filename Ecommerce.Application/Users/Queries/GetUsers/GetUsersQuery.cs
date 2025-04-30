using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Users.Queries.GetUsers;

public record GetUsersQuery(int Page, int Limit) : IRequest<ErrorOr<List<User>>>;

public class GetUsersQueryHandler(IUserRepository userRepository, ICacheRepository cache)
    : IRequestHandler<GetUsersQuery, ErrorOr<List<User>>>
{
    public async Task<ErrorOr<List<User>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Users{request.Page + "_" + request.Limit}";

        var users = await cache.GetCacheValueAsync<List<User>>(cacheKey, cancellationToken);

        if (users != null)
            return users;

        users = await userRepository.GetAllUser(request.Page, request.Limit, cancellationToken);

        await cache.SetCacheValue(cacheKey, users, cancellationToken);

        return users;
    }
}
