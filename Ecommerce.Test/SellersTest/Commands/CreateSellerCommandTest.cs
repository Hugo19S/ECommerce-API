using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Sellers.Commands.CreateSeller;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.SellersTest.Commands;

public class CreateSellerCommandTest
{
    [Fact]
    public async void CreateSellerCommand_Return_Seller_Conflict()
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

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateSellerCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        CreateSellerCommand request = new(It.IsAny<string>());

        var createSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createSellerResult.IsError);
        Assert.Equal(DomainErrors.Conflict("Seller"), createSellerResult.FirstError);
    }

    [Fact]
    public async void CreateSellerCommand_Return_Seller_Created()
    {
        var mockUserRepository = new Mock<ISellerRepository>();

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateSellerCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        CreateSellerCommand request = new(It.IsAny<string>());

        var createSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createSellerResult.IsError);
        Assert.Equal(new Created(), createSellerResult);
    }
}
