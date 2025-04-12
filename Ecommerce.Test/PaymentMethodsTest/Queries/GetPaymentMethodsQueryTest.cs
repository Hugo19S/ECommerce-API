using Ecommerce.Application.IRepositories;
using Ecommerce.Application.PaymentMethods.Queries.GetPaymentMethods;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.PaymentMethodsTest.Queries;

public class GetPaymentMethodsQueryTest
{
    [Fact]
    public async void GetPaymentMethodsQuery_Return_PaymentMethod()
    {
        List<PaymentMethod?> paymentMethods = 
        [
            new PaymentMethod
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                CreatedAt = DateTimeOffset.UtcNow,
            }
        ];

        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        mockPaymentMethodRepositoryRepository
            .Setup(x => x.GetAllPaymentMethod(It.IsAny<CancellationToken>()))
            .ReturnsAsync(paymentMethods);

        GetPaymentMethodsQueryHandler handler = new(mockPaymentMethodRepositoryRepository.Object);

        GetPaymentMethodsQuery request = new();

        var getPaymentMethodsResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getPaymentMethodsResponse.IsError);

        Assert.Equal(paymentMethods, getPaymentMethodsResponse);
    }
}
