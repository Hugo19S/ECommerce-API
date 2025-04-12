using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.PaymentMethods.Commands.CreatePaymentMethod;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.PaymentMethodsTest.Commands;

public class CreatePaymentMethodCommandTest
{
    [Fact]
    public async void CreatePaymentMethodCommand_Return_Conflict()
    {
        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        mockPaymentMethodRepositoryRepository.Setup(x => x.GetPaymentMethodByName(It.IsAny<string>(), 
                                                                                  It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaymentMethod());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreatePaymentMethodCommandHandler handler = new(mockPaymentMethodRepositoryRepository.Object,
                                                        mockUnitOfWorkRepository.Object);

        CreatePaymentMethodCommand request = new(It.IsAny<string>());

        var createPaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(createPaymentMethodResponse.IsError);

        Assert.Equal(DomainErrors.Conflict("PaymentMethod"), createPaymentMethodResponse.FirstError);
    }
    
    [Fact]
    public async void CreatePaymentMethodCommand_Return_Created()
    {
        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreatePaymentMethodCommandHandler handler = new(mockPaymentMethodRepositoryRepository.Object,
                                                        mockUnitOfWorkRepository.Object);

        CreatePaymentMethodCommand request = new(It.IsAny<string>());

        var createPaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(createPaymentMethodResponse.IsError);

        Assert.Equal(new Created(), createPaymentMethodResponse);
    }
}
