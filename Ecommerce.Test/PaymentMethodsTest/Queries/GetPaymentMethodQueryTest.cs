using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.PaymentMethods.Queries.GetPaymentMethod;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.PaymentMethodsTest.Queries;

public class GetPaymentMethodQueryTest
{
    [Fact]
    public async void GetPaymentMethodQuery_Return_NotFound()
    {
        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();

        GetPaymentMethodQueryHandler handler = new(mockPaymentMethodRepositoryRepository.Object);

        GetPaymentMethodQuery request = new(It.IsAny<Guid>());

        var getPaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(getPaymentMethodResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("PaymentMethod", request.PaymentMethodId),
                                           getPaymentMethodResponse.FirstError);
    }
    
    [Fact]
    public async void GetPaymentMethodQuery_Return_PaymentMethod()
    {
        var paymentMethod = new PaymentMethod { 
            Id = Guid.NewGuid() ,
            Name = "Test" ,
            CreatedAt = DateTimeOffset.UtcNow,
        };

        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        mockPaymentMethodRepositoryRepository
            .Setup(x => x.GetPaymentMethodById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(paymentMethod);

        GetPaymentMethodQueryHandler handler = new(mockPaymentMethodRepositoryRepository.Object);

        GetPaymentMethodQuery request = new(It.IsAny<Guid>());

        var getPaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(getPaymentMethodResponse.IsError);

        Assert.Equal(paymentMethod, getPaymentMethodResponse);
    }
}
