using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Users.Commands.UpdateUser;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.UsersTest.Commands;

public class UpdateUserCommandTest
{
    [Fact]
    public async void UpdateUserCommand_Return_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateUserCommandHandler handler = new(mockUserRepository.Object,
                                               mockUnitOfWorkRepository.Object);

        UpdateUserCommand request = new(It.IsAny<Guid>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>());

        var updateUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updateUserResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("User", request.UserId), updateUserResponse.FirstError);
    }
    
    [Fact]
    public async void UpdateUserCommand_Return_Conflict()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        mockUserRepository.Setup(x => x.GetUserByEmail(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateUserCommandHandler handler = new(mockUserRepository.Object,
                                               mockUnitOfWorkRepository.Object);

        UpdateUserCommand request = new(It.IsAny<Guid>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>());

        var updateUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updateUserResponse.IsError);

        Assert.Equal(DomainErrors.Conflict("User"), updateUserResponse.FirstError);
    }
    
    [Fact]
    public async void UpdateUserCommand_Return_Updated()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        mockUserRepository.Setup(x => x.UpdateUser(It.IsAny<Guid>(), 
                                                   It.IsAny<string>(), 
                                                   It.IsAny<string>(), 
                                                   It.IsAny<string>(),
                                                   It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateUserCommandHandler handler = new(mockUserRepository.Object,
                                               mockUnitOfWorkRepository.Object);

        UpdateUserCommand request = new(It.IsAny<Guid>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>(),
                                        It.IsAny<string>());

        var updateUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(updateUserResponse.IsError);

        Assert.Equal(new Updated(), updateUserResponse);
    }
}
