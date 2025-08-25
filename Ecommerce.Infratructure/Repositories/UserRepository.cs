using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.AppSettings;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;
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

    //keycloak
    public async Task<Guid> AddUserToKeycloak(UserKeycloak user, HttpClient http, CancellationToken cancellationToken)
    {

        var userRequest = new HttpRequestMessage(HttpMethod.Post, options.Value.UserEndpoint)
        {
            Content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json")
        };

        var userResponse = await http.SendAsync(userRequest, cancellationToken);

        var responseBody = await userResponse.Content.ReadAsStringAsync(cancellationToken);
        Console.WriteLine("Response body: " + responseBody);

        userResponse.EnsureSuccessStatusCode();

        string locationHeader = userResponse.Headers.Location!.ToString();

        return Guid.Parse(locationHeader[(locationHeader.LastIndexOf('/') + 1)..]);
    }

    public async Task<string> GetUserAdminKeycloakToken(HttpClient http, CancellationToken cancellationToken)
    {
        var keycloakSettings = options.Value;

        var tokenRequest = new HttpRequestMessage(HttpMethod.Post, keycloakSettings.TokenEndpoint)
        {
            Content = new FormUrlEncodedContent(
            [
                new KeyValuePair<string, string>("client_id", "public-client"),
                new KeyValuePair<string, string>("username", keycloakSettings.AdminUsername),
                new KeyValuePair<string, string>("password", keycloakSettings.AdminPassword),
                new KeyValuePair<string, string>("grant_type", "password")
            ])
        };

        var tokenResponse = await http.SendAsync(tokenRequest, cancellationToken);
        tokenResponse.EnsureSuccessStatusCode();

        using var tokenJson = JsonDocument.Parse(await tokenResponse.Content.ReadAsStringAsync(cancellationToken));
        string token = tokenJson.RootElement.GetProperty("access_token").GetString()!;
        return token;
    }

    public async Task AssignRoleToKeycloakUser(Guid userKeycloakId, string role, HttpClient http, CancellationToken cancellationToken)
    {
        var roleResponse = await http.GetAsync($"{options.Value.UserApiBase}/roles/{role}", cancellationToken);
        roleResponse.EnsureSuccessStatusCode();

        var roleJsonString = await roleResponse.Content.ReadAsStringAsync(cancellationToken);
        var roleDoc = JsonDocument.Parse(roleJsonString);
        var roleId = roleDoc.RootElement.GetProperty("id").GetString();
        var roleName = roleDoc.RootElement.GetProperty("name").GetString();

        var roleToAdd = new[]
        {
            new{
                id = roleId,
                name = roleName,
            }
        };

        var roleAssignRequest = new HttpRequestMessage(
            HttpMethod.Post,
            $"{options.Value.UserApiBase}/users/{userKeycloakId}/role-mappings/realm")
        {
            Content = new StringContent(JsonSerializer.Serialize(roleToAdd), Encoding.UTF8, "application/json")
        };

        var assignResponse = await http.SendAsync(roleAssignRequest, cancellationToken);
        assignResponse.EnsureSuccessStatusCode();
    }

    public Task<string> AuthenticateUser(string username, string password, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
