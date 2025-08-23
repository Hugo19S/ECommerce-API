using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.AppSettings;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Runtime;
using System.Text.Json;

namespace Ecommerce.Infratructure.Repositories;

public class UserRepository(ECommerceDbContext dbContext, IOptions<KeycloakSettings> options) : IUserRepository
{
    public async Task AddUser(User user, CancellationToken cancellationToken)
    {
        await dbContext.User.AddAsync(user, cancellationToken);
    }
    public async Task<List<User>> GetAllUser(int page, int limit, CancellationToken cancellationToken)
    {
        var skip = (page - 1) * limit;

        return await dbContext.User
            .Skip(skip)
            .Take(limit)
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .ToListAsync(cancellationToken);
    }

    public async Task<User?> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.User.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);
    }
    
    public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
    {
        return await dbContext.User.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task DeleteUser(Guid userId, CancellationToken cancellationToken)
    {
        await dbContext.User.Where(x=>x.Id == userId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task UpdateUser(Guid userId,string email,string phoneNumber,
                                 string address, CancellationToken cancellationToken)
    {
        await dbContext.User.Where(x => x.Id == userId)
            .ExecuteUpdateAsync(x => x
            .SetProperty(p => p.Email, email)
            .SetProperty(p => p.PhoneNumber, phoneNumber)
            .SetProperty(p => p.Address, address),
            cancellationToken);
    }

    public Task<string> AddUserToKeycloak(User user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserKeycloakToken(User user, CancellationToken cancellationToken)
    {
        /*var tokenRequest = new HttpRequestMessage(HttpMethod.Post, $"{keycloakUrl}/realms/{realm}/protocol/openid-connect/token")
        {
            Content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("client_id", "public-client"),
                new KeyValuePair<string, string>("username", adminUser),
                new KeyValuePair<string, string>("password", adminPass),
                new KeyValuePair<string, string>("grant_type", "password")
            ])
        };

        var tokenResponse = await http.SendAsync(tokenRequest);
        tokenResponse.EnsureSuccessStatusCode();

        using var tokenJson = JsonDocument.Parse(await tokenResponse.Content.ReadAsStringAsync());
        string token = tokenJson.RootElement.GetProperty("access_token").GetString();
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);*/
        throw new NotImplementedException();
    }

    public Task AssignRoleToKeycloakUser(string userId, string roleName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetKeycloakUserPassword(string userId, string newPassword, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> AuthenticateUser(string username, string password, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
