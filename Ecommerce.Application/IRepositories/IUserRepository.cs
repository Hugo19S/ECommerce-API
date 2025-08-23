using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IUserRepository
{
    Task AddUser(User user, CancellationToken cancellationToken);
    Task<User?> GetUserById(Guid userId, CancellationToken cancellationToken);
    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
    Task<List<User>> GetAllUser(int page, int limit, CancellationToken cancellationToken);
    Task UpdateUser(Guid userId, string email, string phoneNumber, string address, CancellationToken cancellationToken);
    Task DeleteUser(Guid userId, CancellationToken cancellationToken);

    //Keycloack
    Task<string> AddUserToKeycloak(User user, CancellationToken cancellationToken);
    Task<string> GetUserKeycloakToken(User user, CancellationToken cancellationToken);
    Task AssignRoleToKeycloakUser(string userId, string roleName, CancellationToken cancellationToken);
    Task SetKeycloakUserPassword(string userId, string newPassword, CancellationToken cancellationToken);
    Task<string> AuthenticateUser(string username, string password, CancellationToken cancellationToken);
}
