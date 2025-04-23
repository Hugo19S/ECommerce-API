using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IUserRepository
{
    Task AddUser(User user, CancellationToken cancellationToken);
    Task<User?> GetUserById(Guid userId, CancellationToken cancellationToken);
    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
    Task<List<User>> GetAllUser(CancellationToken cancellationToken);
    Task UpdateUser(Guid userId, string email, string phoneNumber, string address, CancellationToken cancellationToken);
    Task DeleteUser(Guid userId, CancellationToken cancellationToken);
}
