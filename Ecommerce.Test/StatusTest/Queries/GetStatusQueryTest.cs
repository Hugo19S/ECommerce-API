using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Statuses.Queries.GetStatus;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.StatusTest.Queries;

public class GetStatusQueryTest
{
    [Fact]
    public async void GetStatusQuery_Return_NotFound()
    {
        var mockStatusRepository = new Mock<IStatusRepository>();

        GetStatusQueryHandler handler = new(mockStatusRepository.Object);

        GetStatusQuery request = new(It.IsAny<Guid>());

        var getStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(getStatusResponse.IsError);
        Assert.Equal(DomainErrors.NotFound("Status", request.StatusId), getStatusResponse.FirstError);
    }
    
    [Fact]
    public async void GetStatusQuery_Return_Status()
    {
        var status = new Status
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Type = "Test"
        };

        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(status);

        GetStatusQueryHandler handler = new(mockStatusRepository.Object);

        GetStatusQuery request = new(It.IsAny<Guid>());

        var getStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getStatusResponse.IsError);
        Assert.Equal(status, getStatusResponse);
    }
}
