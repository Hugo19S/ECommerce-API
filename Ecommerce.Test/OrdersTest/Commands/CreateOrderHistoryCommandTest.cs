using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Orders.Commands.CreateOrderHistory;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.OrdersTest.Commands;

public class CreateOrderHistoryCommandTest
{
    [Fact]
    public async void CreateOrderHistoryCommand_Return_Order_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateOrderHistoryCommandHandler handler = new(
            mockOrderRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateOrderHistoryCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>());

        var createOrderHistoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createOrderHistoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Order", request.OrderId),
                     createOrderHistoryResult.FirstError);
    }
    
    [Fact]
    public async void CreateOrderHistoryCommand_Return_Status_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateOrderHistoryCommandHandler handler = new(
            mockOrderRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateOrderHistoryCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>());

        var createOrderHistoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createOrderHistoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Status", request.OrderId),
                     createOrderHistoryResult.FirstError);
    }
    
    [Fact]
    public async void CreateOrderHistoryCommand_Return_Created()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        mockOrderRepository.Setup(x => x.AddOrder(new Order(), It.IsAny<CancellationToken>()));
        mockOrderRepository.Setup(x => x.UpdateOrder(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateOrderHistoryCommandHandler handler = new(
            mockOrderRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateOrderHistoryCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<string>());

        var createOrderHistoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createOrderHistoryResult.IsError);
        Assert.Equal(new Created(), createOrderHistoryResult);
    }
}
