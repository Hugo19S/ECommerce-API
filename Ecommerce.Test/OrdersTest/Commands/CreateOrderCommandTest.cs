using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Orders.Commands.CreateOrder;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.OrdersTest.Commands;

public class CreateOrderCommandTest
{
    [Fact]
    public async void CreateOrderCommand_Return_User_NotFound() 
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockUserRepository = new Mock<IUserRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateOrderCommandHandler handler = new(
            mockOrderRepository.Object,
            mockUserRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateOrderCommand request = new(It.IsAny<Guid>(), It.IsAny<float>(), new List<OrderItemsRequest>());

        var createOrderResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createOrderResult.IsError);
        Assert.Equal(DomainErrors.NotFound("User", request.UserId),
                     createOrderResult.FirstError);
    }
    
    [Fact]
    public async void CreateOrderCommand_Return_Product_NotFound() 
    {
        List<OrderItemsRequest> orderItems = new()
        {
            new OrderItemsRequest()
            {
                ProductId = Guid.NewGuid(),
                Quantity = 1
            }
        };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.AddOrder(new Order(), It.IsAny<CancellationToken>()));

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());
        

        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateOrderCommandHandler handler = new(
            mockOrderRepository.Object,
            mockUserRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateOrderCommand request = new(It.IsAny<Guid>(), It.IsAny<float>(), orderItems);

        var createOrderResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createOrderResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Product", request.OrderItems[0].ProductId),
                     createOrderResult.FirstError);
    }
    
    [Fact]
    public async void CreateOrderCommand_Return_Created() 
    {
        List<OrderItemsRequest> orderItems = new()
        {
            new OrderItemsRequest()
            {
                ProductId = Guid.NewGuid(),
                Quantity = 1
            }
        };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.AddOrder(new Order(), It.IsAny<CancellationToken>()));
        mockOrderRepository.Setup(x => x.AddOrderItems(new OrderItems(), It.IsAny<CancellationToken>()));
        mockOrderRepository.Setup(x => x.AddOrderHistory(new OrderStatusHistory(), It.IsAny<CancellationToken>()));

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(x => x.GetProductById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ProductDto());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateOrderCommandHandler handler = new(
            mockOrderRepository.Object,
            mockUserRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateOrderCommand request = new(It.IsAny<Guid>(), It.IsAny<float>(), orderItems);

        var createOrderResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createOrderResult.IsError);
        Assert.Equal(new Created(), createOrderResult);
    }
}
