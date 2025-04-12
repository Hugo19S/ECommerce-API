using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Users.Queries.GetUsers;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.UsersTest.Queries;

public class GetUsersQueryTest
{
    [Fact]
    public async void GetUsersQuery_Return_User()
    {
        List<User> users =
        [
            new User
            {
                Id = Guid.NewGuid(),
                UserRoleId = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@test.com",
                Password = "Test",
                Address = "Test",
                CreatedAt = DateTimeOffset.Now
            }
        ];
        
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetAllUser(It.IsAny<CancellationToken>()))
            .ReturnsAsync(users);

        GetUsersQueryHandler handler = new(mockUserRepository.Object);

        GetUsersQuery request = new();

        var getUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getUserResponse.IsError);

        Assert.Equal(users, getUserResponse);
    }
}
