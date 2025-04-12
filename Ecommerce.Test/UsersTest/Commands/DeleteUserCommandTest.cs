using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Users.Commands.DeleteUser;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.UsersTest.Commands;

public class DeleteUserCommandTest
{
    [Fact]
    public async void DeleteUserCommand_Return_NotFound() 
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeleteUserCommandHandler handler = new(mockUserRepository.Object,
                                               mockUnitOfWorkRepository.Object);

        DeleteUserCommand request = new(It.IsAny<Guid>());

        var deleteUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(deleteUserResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("User", request.UserId), deleteUserResponse.FirstError);
    }

    [Fact]
    public async void DeleteUserCommand_Return_Deleted() 
    {
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        mockUserRepository.Setup(x => x.DeleteUser(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeleteUserCommandHandler handler = new(mockUserRepository.Object,
                                               mockUnitOfWorkRepository.Object);

        DeleteUserCommand request = new(It.IsAny<Guid>());

        var deleteUserResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(deleteUserResponse.IsError);

        Assert.Equal(new Deleted(), deleteUserResponse);
    }
}
