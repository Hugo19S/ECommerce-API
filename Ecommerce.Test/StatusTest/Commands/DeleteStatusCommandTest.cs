using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Statuses.Commands.DeleteStatus;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.StatusTest.Commands;

public class DeleteStatusCommandTest
{
    [Fact]
    public async void DeleteStatusCommand_Return_NotFound()
    {
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeleteStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        DeleteStatusCommand request = new(It.IsAny<Guid>());

        var deleteStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(deleteStatusResponse.IsError);
        Assert.Equal(DomainErrors.NotFound("Status", request.StatusId), deleteStatusResponse.FirstError);
    }
    
    [Fact]
    public async void DeleteStatusCommand_Return_Deleted()
    {
        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());
        
        mockStatusRepository.Setup(x => x.DeleteStatus(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeleteStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        DeleteStatusCommand request = new(It.IsAny<Guid>());

        var deleteStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(deleteStatusResponse.IsError);
        Assert.Equal(new Deleted(), deleteStatusResponse);
    }
}
