using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Statuses.Commands.UpdateStatus;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.StatusTest.Commands;

public class UpdateStatusCommandTest
{
    [Fact]
    public async void UpdateStatusCommand_Return_NotFound()
    {
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        UpdateStatusCommand request = new(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

        var updateStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updateStatusResponse.IsError);
        Assert.Equal(DomainErrors.NotFound("Status", request.StatusId), updateStatusResponse.FirstError);
    }
    
    [Fact]
    public async void UpdateStatusCommand_Return_Updated()
    {
        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());
        
        mockStatusRepository.Setup(x => x.UpdateStatus(It.IsAny<Guid>(),
                                                       It.IsAny<string>(),
                                                       It.IsAny<string>(),
                                                       It.IsAny<string>(),
                                                       It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        UpdateStatusCommand request = new(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

        var updateStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(updateStatusResponse.IsError);
        Assert.Equal(new Updated(), updateStatusResponse);
    }
}
