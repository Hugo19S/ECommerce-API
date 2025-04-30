using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Users.Queries.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<ErrorOr<User>>;

public class GetUserQueryHandler(IUserRepository userRepository, ICacheRepository cache)
    : IRequestHandler<GetUserQuery, ErrorOr<User>>
{
    public async Task<ErrorOr<User>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var cacheKey = $"{request.UserId}";

        var user = await cache.GetCacheValueAsync<User>(cacheKey, cancellationToken);

        if (user != null)
            return user;

        user = await userRepository.GetUserById(request.UserId, cancellationToken);

        if (user == null)
            return DomainErrors.NotFound("User", request.UserId);

        await cache.SetCacheValue(cacheKey, user, cancellationToken);

        return user;
    }
}
