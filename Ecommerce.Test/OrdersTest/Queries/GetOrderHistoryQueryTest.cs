using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Orders.Queries.GetOrderHistory;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.OrdersTest.Queries;

public class GetOrderHistoryQueryTest
{
    [Fact]
    public async void GetOrderHistory_Return_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();

        GetOrderHistoryQueryHandler handler = new(mockOrderRepository.Object);

        GetOrderHistoryQuery request = new(It.IsAny<Guid>());

        var getOrderHistoryResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(getOrderHistoryResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("Order", request.OrderId), getOrderHistoryResponse.FirstError);
    }
    
    [Fact]
    public async void GetOrderHistory_Return_OrderStatusHistory()
    {
        List<OrderStatusHistory> orderStatusHistories = 
        [
            new()
            {
                Id = Guid.NewGuid(),
                OrderId = Guid.NewGuid(),
                StatusId = Guid.NewGuid(),
                Note = "Test",
                CreatedAt = DateTimeOffset.UtcNow,
            }
        ];

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository
            .Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());
        
        mockOrderRepository
            .Setup(x => x.GetOrderHistory(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(orderStatusHistories);

        GetOrderHistoryQueryHandler handler = new(mockOrderRepository.Object);

        GetOrderHistoryQuery request = new(It.IsAny<Guid>());

        var getOrderHistoryResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getOrderHistoryResponse.IsError);

        Assert.Equal(orderStatusHistories, getOrderHistoryResponse);
    }
}
