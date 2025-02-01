using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

internal interface IUserRepository
{
    Task<ErrorOr<Created>> AddUser(User user, CancellationToken cancellationToken);
    Task<ErrorOr<User>> GetUserById(Guid userId, CancellationToken cancellationToken);
    Task<List<User>> GetAllUser(CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateUser(User user, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteUser(Guid userId, CancellationToken cancellationToken);
}
