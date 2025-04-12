using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Payments.Commands.CreatePayment;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.PaymentsTets.Commands;

public class CreatePaymentCommandTest
{
    [Fact]
    public async void CreatePaymentCommand_Return_Order_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockPaymentMethodRepository = new Mock<IPaymentMethodRepository>();
        var mockPaymentRepository = new Mock<IPaymentRepository>();
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreatePaymentCommandHandler handler = new(
            mockOrderRepository.Object,
            mockPaymentMethodRepository.Object,
            mockPaymentRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWork.Object);

        CreatePaymentCommand request = new(
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<float>(),
            It.IsAny<float>(),
            It.IsAny<string>(),
            It.IsAny<int>());

        var createPaymentResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createPaymentResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Order", request.OrderId),
                     createPaymentResult.FirstError);
    }

    [Fact]
    public async void CreatePaymentCommand_Return_PaymentMethod_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockPaymentMethodRepository = new Mock<IPaymentMethodRepository>();
        var mockPaymentRepository = new Mock<IPaymentRepository>();
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreatePaymentCommandHandler handler = new(
            mockOrderRepository.Object,
            mockPaymentMethodRepository.Object,
            mockPaymentRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWork.Object);

        CreatePaymentCommand request = new(
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<float>(),
            It.IsAny<float>(),
            It.IsAny<string>(),
            It.IsAny<int>());

        var createPaymentResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createPaymentResult.IsError);
        Assert.Equal(DomainErrors.NotFound("PaymentMethod", request.PaymentMethodId),
                     createPaymentResult.FirstError);
    }

    [Fact]
    public async void CreatePaymentCommand_Return_Status_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockPaymentMethodRepository = new Mock<IPaymentMethodRepository>();
        mockPaymentMethodRepository.Setup(x => x.GetPaymentMethodById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaymentMethod());

        var mockPaymentRepository = new Mock<IPaymentRepository>();
        var mockStatusRepository = new Mock<IStatusRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreatePaymentCommandHandler handler = new(
            mockOrderRepository.Object,
            mockPaymentMethodRepository.Object,
            mockPaymentRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWork.Object);

        CreatePaymentCommand request = new(
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<float>(),
            It.IsAny<float>(),
            It.IsAny<string>(),
            It.IsAny<int>());

        var createPaymentResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createPaymentResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Status", request.PaymentMethodId),
                     createPaymentResult.FirstError);
    }

    [Fact]
    public async void CreatePaymentCommand_Return_Created()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockPaymentMethodRepository = new Mock<IPaymentMethodRepository>();
        mockPaymentMethodRepository.Setup(x => x.GetPaymentMethodById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaymentMethod());

        var mockPaymentRepository = new Mock<IPaymentRepository>();
        mockPaymentRepository.Setup(x => x.AddPayment(new Payment(), It.IsAny<CancellationToken>()));
        mockPaymentRepository.Setup(x => x.AddPaymentHistory(new PaymentStatusHistory(), It.IsAny<CancellationToken>()));

        var mockStatusRepository = new Mock<IStatusRepository>();
        mockStatusRepository.Setup(x => x.GetStatusById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Status());

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreatePaymentCommandHandler handler = new(
            mockOrderRepository.Object,
            mockPaymentMethodRepository.Object,
            mockPaymentRepository.Object,
            mockStatusRepository.Object,
            mockUnitOfWork.Object);

        CreatePaymentCommand request = new(
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<Guid>(),
            It.IsAny<float>(),
            It.IsAny<float>(),
            It.IsAny<string>(),
            It.IsAny<int>());

        var createPaymentResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createPaymentResult.IsError);
        Assert.Equal(new Created(), createPaymentResult);
    }
}
