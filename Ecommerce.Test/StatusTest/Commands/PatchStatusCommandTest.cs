using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Statuses.Commands.PatchStatus;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Microsoft.AspNetCore.JsonPatch;
using Moq;

namespace Ecommerce.Tests.StatusTest.Commands;

public class PatchStatusCommandTest
{
    [Fact]
    public async void PatchStatusCommand_Return_JSonPatchNotFound()
    {
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        PatchStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        PatchStatusCommand request = new(It.IsAny<Guid>(), It.IsAny<JsonPatchDocument<Status>>());

        var updateStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updateStatusResponse.IsError);
        Assert.Equal(DomainErrors.JSonPatchNotFound(), updateStatusResponse.FirstError);
    }

    [Fact]
    public async void PatchStatusCommand_Return_OperationUnauthorized()
    {
        JsonPatchDocument<Status> jsonPatchDocument = new();
        jsonPatchDocument.Move(x => x.Name, x => x.Description);

        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        PatchStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        PatchStatusCommand request = new(It.IsAny<Guid>(), jsonPatchDocument);

        var updateStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updateStatusResponse.IsError);
        Assert.Equal(DomainErrors.OperationUnauthorized(), updateStatusResponse.FirstError);
    }
    
    [Fact]
    public async void PatchStatusCommand_Return_NotFound()
    {
        JsonPatchDocument<Status> jsonPatchDocument = new();
        jsonPatchDocument.Replace(x => x.Name, "Test");

        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        PatchStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        PatchStatusCommand request = new(It.IsAny<Guid>(), jsonPatchDocument);

        var updateStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updateStatusResponse.IsError);
        Assert.Equal(DomainErrors.NotFound("Status", request.StatusId), updateStatusResponse.FirstError);
    }
    
    [Fact]
    public async void PatchStatusCommand_Return_Conflict()
    {
        JsonPatchDocument<Status> jsonPatchDocument = new();
        jsonPatchDocument.Replace(x => x.Name, "Test");

        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());
        
        mockStatusRepository.Setup(x => x.GetStatusByName(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        PatchStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        PatchStatusCommand request = new(It.IsAny<Guid>(), jsonPatchDocument);

        var updateStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updateStatusResponse.IsError);
        Assert.Equal(DomainErrors.Conflict("Status"), updateStatusResponse.FirstError);
    }
    
    [Fact]
    public async void PatchStatusCommand_Return_Updated()
    {
        JsonPatchDocument<Status> jsonPatchDocument = new();
        jsonPatchDocument.Replace(x => x.Name, "Test");

        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        PatchStatusCommandHandler handler = new(mockStatusRepository.Object, mockUnitOfWorkRepository.Object);

        PatchStatusCommand request = new(It.IsAny<Guid>(), jsonPatchDocument);

        var updateStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(updateStatusResponse.IsError);
        Assert.Equal(new Updated(), updateStatusResponse);
    }
}
