using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Payments.Queries.GetPayment;
using Ecommerce.Domain.Common;
using Moq;

namespace Ecommerce.Tests.PaymentsTets.Queries;

public class GetPaymentCommandTest
{
    [Fact]
    public async void GetPaymentQuery_Return_Order_NotFound()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        var mockPaymentRepository = new Mock<IPaymentRepository>();

        GetPaymentQueryHandler handler = new(mockPaymentRepository.Object, mockOrderRepository.Object);

        GetPaymentQuery request = new(It.IsAny<Guid>());

        var getPaymentResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(getPaymentResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Order", request.OrderId), getPaymentResult.FirstError);
    }

    [Fact]
    public async void GetPaymentQuery_Return_Order_NotFound_In_Payment()
    {
        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockPaymentRepository = new Mock<IPaymentRepository>();

        GetPaymentQueryHandler handler = new(mockPaymentRepository.Object, mockOrderRepository.Object);

        GetPaymentQuery request = new(It.IsAny<Guid>());

        var getPaymentResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(getPaymentResult.IsError);
        Assert.Equal(DomainErrors.Generic("Order", "Payment"), getPaymentResult.FirstError);
    }

    [Fact]
    public async void GetPaymentQuery_Return_PaymentDto()
    {
        var paymentDto = new PaymentDto
        {
            Id = Guid.NewGuid(),
            TotalPayable = 0,
            InstallmentsNumber = 0,
            CreatedAt = DateTimeOffset.Now
        };

        var mockOrderRepository = new Mock<IOrderRepository>();
        mockOrderRepository.Setup(x => x.GetOrderById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new OrderDto());

        var mockPaymentRepository = new Mock<IPaymentRepository>();
        mockPaymentRepository.Setup(x => x.GetPaymentByOrder(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(paymentDto);

        GetPaymentQueryHandler handler = new(mockPaymentRepository.Object, mockOrderRepository.Object);

        GetPaymentQuery request = new(It.IsAny<Guid>());

        var getPaymentResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(getPaymentResult.IsError);
        Assert.Equal(paymentDto, getPaymentResult);
    }
}
