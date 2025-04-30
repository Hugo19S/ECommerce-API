using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Users.Queries.GetUser;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.UsersTest.Queries;

public class GetUserQueryTest
{
    [Fact]
    public async void GetUserQuery_Return_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockCacheRepository = new Mock<ICacheRepository>();

        GetUserQueryHandler handler = new(mockUserRepository.Object, mockCacheRepository.Object);

        GetUserQuery request = new(It.IsAny<Guid>());

        var getUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(getUserResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("User", request.UserId), getUserResponse.FirstError);
    }
    
    [Fact]
    public async void GetUserQuery_Return_User()
    {
        User user = new() 
        {
            Id = Guid.NewGuid(),
            FirstName = "Test",
            LastName = "Test",
            Email = "Test@test.com",
            Password = "Test",
            Address = "Test",
            CreatedAt = DateTimeOffset.Now
        };
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user);

        var mockCacheRepository = new Mock<ICacheRepository>();

        GetUserQueryHandler handler = new(mockUserRepository.Object, mockCacheRepository.Object);

        GetUserQuery request = new(It.IsAny<Guid>());

        var getUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getUserResponse.IsError);

        Assert.Equal(user, getUserResponse);
    }
}
