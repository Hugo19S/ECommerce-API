using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Orders.Queries.GetOrder;
using Ecommerce.Domain.Common;
using Moq;

namespace Ecommerce.Tests.OrdersTest.Queries;

public class GetOrderQueryTest
{
    [Fact]
    public async void GetOrderQuery_Return_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();

        GetOrderQueryHandler handler = new(mockOrderRepository.Object);

        GetOrderQuery request = new(It.IsAny<Guid>());

        var getOrderResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(getOrderResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("Order", request.OrderId), getOrderResponse.FirstError);
    }
    
    [Fact]
    public async void GetOrderQuery_Return_OrderDto()
    {
        OrderDto order = new()
        {
            Id = Guid.NewGuid(),
            Total = 0,
            Items = [],
            StatusHistory = [],
            CreatedAt = DateTimeOffset.Now
        };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository
            .Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(order);

        GetOrderQueryHandler handler = new(mockOrderRepository.Object);

        GetOrderQuery request = new(It.IsAny<Guid>());

        var getOrderResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getOrderResponse.IsError);
        Assert.Equal(order, getOrderResponse);
    }
}
