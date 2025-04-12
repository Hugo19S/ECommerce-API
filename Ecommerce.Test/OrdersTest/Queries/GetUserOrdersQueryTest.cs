using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Orders.Queries.GetUserOrders;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.OrdersTest.Queries;

public class GetUserOrdersQueryTest
{
    [Fact]
    public async void GetUserOrdersResponse_Return_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockUserRepository = new Mock<IUserRepository>();

        GetUserOrdersQueryHandler handler = new(mockOrderRepository.Object, mockUserRepository.Object);

        GetUserOrdersQuery request = new(It.IsAny<Guid>());

        var getUserOrdersResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(getUserOrdersResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("User", request.UserId), getUserOrdersResponse.FirstError);
    }

    [Fact]
    public async void GetUserOrdersResponse_Return_UserOrders()
    {
        List<OrderDto> orders =
        [
            new()
            {
                Id = Guid.NewGuid(),
                Total = 0,
                Items = [],
                StatusHistory = [],
                CreatedAt = DateTimeOffset.UtcNow,
            }
        ];

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository
            .Setup(x => x.GetUserOrders(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(orders);

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        GetUserOrdersQueryHandler handler = new(mockOrderRepository.Object, mockUserRepository.Object);

        GetUserOrdersQuery request = new(It.IsAny<Guid>());

        var getUserOrdersResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getUserOrdersResponse.IsError);

        Assert.Equal(orders, getUserOrdersResponse);

    }
}
