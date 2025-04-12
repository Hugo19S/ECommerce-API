using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Payments.Commands.CreatePaymentHistory;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.PaymentsTets.Commands;

public class CreatePaymentHistoryCommandTest
{
    [Fact]
    public async void CreatePaymentHistoryCommand_Return_Order_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockPaymentRepository = new Mock<IPaymentRepository>();
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreatePaymentHistoryCommandHandler handler = new(
            mockOrderRepository.Object,
            mockPaymentRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWork.Object);

        CreatePaymentHistoryCommand request = new(
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<float>(),
            It.IsAny<string>());

        var createPaymentHistoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createPaymentHistoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Order", request.OrderId),
                     createPaymentHistoryResult.FirstError);
    }
    
    [Fact]
    public async void CreatePaymentHistoryCommand_Return_Payment_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockPaymentRepository = new Mock<IPaymentRepository>();
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreatePaymentHistoryCommandHandler handler = new(
            mockOrderRepository.Object,
            mockPaymentRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWork.Object);

        CreatePaymentHistoryCommand request = new(
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<float>(),
            It.IsAny<string>());

        var createPaymentHistoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createPaymentHistoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Payment", request.OrderId),
                     createPaymentHistoryResult.FirstError);
    }
    
    [Fact]
    public async void CreatePaymentHistoryCommand_Return_Status_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockPaymentRepository = new Mock<IPaymentRepository>();
        mockPaymentRepository.Setup(x => x.GetPaymentById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Payment());

        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreatePaymentHistoryCommandHandler handler = new(
            mockOrderRepository.Object,
            mockPaymentRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWork.Object);

        CreatePaymentHistoryCommand request = new(
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<float>(),
            It.IsAny<string>());

        var createPaymentHistoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createPaymentHistoryResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Status", request.OrderId),
                     createPaymentHistoryResult.FirstError);
    }

    [Fact]
    public async void CreatePaymentHistoryCommand_Return_Created()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockPaymentRepository = new Mock<IPaymentRepository>();
        mockPaymentRepository.Setup(x => x.GetPaymentById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Payment());

        mockPaymentRepository.Setup(x => x.AddPaymentHistory(new PaymentStatusHistory(), It.IsAny<CancellationToken>()));

        mockPaymentRepository.Setup(x => x.UpdatePayment(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreatePaymentHistoryCommandHandler handler = new(
            mockOrderRepository.Object,
            mockPaymentRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWork.Object);

        CreatePaymentHistoryCommand request = new(
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<float>(),
            It.IsAny<string>());

        var createPaymentHistoryResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createPaymentHistoryResult.IsError);
        Assert.Equal(new Created(), createPaymentHistoryResult);
    }
}
