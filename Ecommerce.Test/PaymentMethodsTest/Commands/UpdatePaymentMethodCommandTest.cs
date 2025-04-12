using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.PaymentMethods.Commands.UpdatePaymentMethod;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.PaymentMethodsTest.Commands;

public class UpdatePaymentMethodCommandTest
{
    [Fact]
    public async void UpdatePaymentMethodCommand_Return_NotFound()
    {
        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdatePaymentMethodCommandHandler handler = new(mockPaymentMethodRepositoryRepository.Object,
                                                        mockUnitOfWorkRepository.Object);

        UpdatePaymentMethodCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updatePaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updatePaymentMethodResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("PaymentMethod", request.PaymentMethodId), 
                                           updatePaymentMethodResponse.FirstError);
    }
    
    [Fact]
    public async void UpdatePaymentMethodCommand_Return_Conflict()
    {
        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        mockPaymentMethodRepositoryRepository
           .Setup(x => x.GetPaymentMethodById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
           .ReturnsAsync(new PaymentMethod());

        mockPaymentMethodRepositoryRepository
            .Setup(x => x.GetPaymentMethodByName(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaymentMethod());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdatePaymentMethodCommandHandler handler = new(mockPaymentMethodRepositoryRepository.Object,
                                                        mockUnitOfWorkRepository.Object);

        UpdatePaymentMethodCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updatePaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(updatePaymentMethodResponse.IsError);

        Assert.Equal(DomainErrors.Conflict("PaymentMethod"), updatePaymentMethodResponse.FirstError);
    }
    
    [Fact]
    public async void UpdatePaymentMethodCommand_Return_Updated()
    {
        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        mockPaymentMethodRepositoryRepository
           .Setup(x => x.GetPaymentMethodById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
           .ReturnsAsync(new PaymentMethod());

        mockPaymentMethodRepositoryRepository
            .Setup(x => x.UpdatePaymentMethod(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdatePaymentMethodCommandHandler handler = new(mockPaymentMethodRepositoryRepository.Object,
                                                        mockUnitOfWorkRepository.Object);

        UpdatePaymentMethodCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updatePaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(updatePaymentMethodResponse.IsError);

        Assert.Equal(new Updated(), updatePaymentMethodResponse);
    }
}
