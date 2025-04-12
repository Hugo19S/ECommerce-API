using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Statuses.Commands.CreateStatus;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.StatusTest.Commands;

public class CreateStatusCommandTest
{
    [Fact]
    public async void CreateStatusCommand_Return_Conflict()
    {
        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusByName(It.IsAny<string>(), It.IsAny<string>(),It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        CreateStatusCommand request = new(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

        var createStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(createStatusResponse.IsError);
        Assert.Equal(DomainErrors.Conflict("Status"), createStatusResponse.FirstError);
    }

    [Fact]
    public async void CreateStatusCommand_Return_Created()
    {
        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.AddStatus(new Status(), It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        CreateStatusCommand request = new(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

        var createStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(createStatusResponse.IsError);
        Assert.Equal(new Created(), createStatusResponse);
    }
}
