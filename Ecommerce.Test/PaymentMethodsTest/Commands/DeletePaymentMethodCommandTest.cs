using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.PaymentMethods.Commands.DeletePaymentMethod;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.PaymentMethodsTest.Commands;

public class DeletePaymentMethodCommandTest
{
    [Fact]
    public async void DeletePaymentMethodCommand_Return_NotFound()
    {
        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeletePaymentMethodCommandHandler handler = new(mockPaymentMethodRepositoryRepository.Object,
                                                        mockUnitOfWorkRepository.Object);

        DeletePaymentMethodCommand request = new(It.IsAny<Guid>());

        var deletePaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.True(deletePaymentMethodResponse.IsError);

        Assert.Equal(DomainErrors.NotFound("PaymentMethod", request.PaymentMethodId),
                                           deletePaymentMethodResponse.FirstError);
    }
    
    [Fact]
    public async void DeletePaymentMethodCommand_Return_()
    {
        var mockPaymentMethodRepositoryRepository = new Mock<IPaymentMethodRepository>();
        mockPaymentMethodRepositoryRepository
            .Setup(x => x.GetPaymentMethodById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaymentMethod());

        mockPaymentMethodRepositoryRepository
            .Setup(x => x.DeletePaymentMethod(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeletePaymentMethodCommandHandler handler = new(mockPaymentMethodRepositoryRepository.Object,
                                                        mockUnitOfWorkRepository.Object);

        DeletePaymentMethodCommand request = new(It.IsAny<Guid>());

        var deletePaymentMethodResponse = await handler.Handle(request, It.IsAny<CancellationToken>());

        Assert.False(deletePaymentMethodResponse.IsError);

        Assert.Equal(new Deleted(), deletePaymentMethodResponse);
    }
}
