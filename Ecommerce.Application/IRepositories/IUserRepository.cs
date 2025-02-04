using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

public interface IUserRepository
{
    Task<ErrorOr<Created>> AddUser(User user, CancellationToken cancellationToken);
    Task<User?> GetUserById(Guid userId, CancellationToken cancellationToken);
    public Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
    Task<List<User>> GetAllUser(CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateUser(Guid userId,
                                      string email,
                                      string phoneNumber,
                                      string address,
                                      CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteUser(Guid userId, CancellationToken cancellationToken);
}
