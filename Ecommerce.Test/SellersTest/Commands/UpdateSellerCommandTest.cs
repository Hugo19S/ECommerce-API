using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Sellers.Commands.UpdateSeller;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.SellersTest.Commands;

public class UpdateSellerCommandTest
{
    [Fact]
    public async void UpdateSellerCommand_Return_NotFound()
    {
        var mockUserRepository = new Mock<ISellerRepository>();

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateSellerCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        UpdateSellerCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updateSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateSellerResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Seller", request.SellerId), updateSellerResult.FirstError);
    }
    [Fact]
    public async void UpdateSellerCommand_Return_Conflict()
    {
        var seller = new Seller
        {
            Id = Guid.NewGuid(),
            Name = "name",
            CreatedAt = DateTimeOffset.UtcNow
        };

        var mockUserRepository = new Mock<ISellerRepository>();
        mockUserRepository.Setup(x => x.GetSellerByName(It.IsAny<string>(), CancellationToken.None))
                          .ReturnsAsync(seller);
        
        mockUserRepository.Setup(x => x.GetSellerById(It.IsAny<Guid>(), CancellationToken.None))
                          .ReturnsAsync(seller);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateSellerCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        UpdateSellerCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updateSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateSellerResult.IsError);
        Assert.Equal(DomainErrors.Conflict("Seller"), updateSellerResult.FirstError);
    }

    [Fact]
    public async void UpdateSellerCommand_Return_Seller_Created()
    {
        var seller = new Seller
        {
            Id = Guid.NewGuid(),
            Name = "name",
            CreatedAt = DateTimeOffset.UtcNow
        };

        var mockUserRepository = new Mock<ISellerRepository>();
        mockUserRepository.Setup(x => x.GetSellerById(It.IsAny<Guid>(), CancellationToken.None))
                          .ReturnsAsync(seller);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateSellerCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        UpdateSellerCommand request = new(It.IsAny<Guid>(), It.IsAny<string>());

        var updateSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(updateSellerResult.IsError);
        Assert.Equal(new Updated(), updateSellerResult);
    }
}
