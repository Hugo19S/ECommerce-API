using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Users.Commands.CreateUser;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.UsersTest.Commands;

public class CreateUserCommandTest
{
    [Fact]
    public async void CreateUserCommand_Return_Conflict()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserByEmail(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var mockCartRepository = new Mock<ICartRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateUserCommandHandler handler = new(mockUserRepository.Object,
                                               mockCartRepository.Object,
                                               mockUnitOfWorkRepository.Object);

        CreateUserCommand request = new(It.IsAny<string>(), 
                                        It.IsAny<string>(), 
                                        It.IsAny<string>(), 
                                        It.IsAny<string>(), 
                                        It.IsAny<string>(), 
                                        It.IsAny<string>());

        var createUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(createUserResponse.IsError);

        Assert.Equal(DomainErrors.Conflict("User"), createUserResponse.FirstError);
    }

    [Fact]
    public async void CreateUserCommand_Return_Created() 
    {
        var mockUserRepository = new Mock<IUserRepository>();
        
        mockUserRepository.Setup(x => x.AddUser(new User(), It.IsAny<CancellationToken>()));

        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(x => x.CreateUserCart(new Cart(), It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateUserCommandHandler handler = new(mockUserRepository.Object,
                                               mockCartRepository.Object,
                                               mockUnitOfWorkRepository.Object);

        CreateUserCommand request = new(It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        "Test",
                                        It.IsAny<string>(),
                                        It.IsAny<string>());

        var createUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(createUserResponse.IsError);

        Assert.Equal(new Created(), createUserResponse);
    }


}
