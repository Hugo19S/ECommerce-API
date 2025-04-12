using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Statuses.Queries.GetStatuses;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.StatusTest.Queries;

public class GetStatusesQueryTest
{
    [Fact]
    public async void GetStatusesQuery_Return_Status_List()
    {
        List<Status> status = 
        [
            new Status
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Type = "Test"
            }
        ];

        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetAllStatus(It.IsAny<CancellationToken>()))
            .ReturnsAsync(status);

        GetStatusesQueryHandler handler = new(mockStatusRepository.Object);

        GetStatusesQuery request = new();

        var getStatusResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getStatusResponse.IsError);
        Assert.Equal(status, getStatusResponse);
    }
}
