using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Sellers.Commands.DeleteSeller;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.SellersTest.Commands;

public class DeleteSellerCommandTest
{
    [Fact]
    public async void DeleteSellerCommand_Return_NotFound()
    {
        var mockUserRepository = new Mock<ISellerRepository>();

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        DeleteSellerCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        DeleteSellerCommand request = new(It.IsAny<Guid>());

        var deleteSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(deleteSellerResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Seller", request.SellerId), deleteSellerResult.FirstError);
    }

    [Fact]
    public async void DeleteSellerCommand_Return_Deleted()
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

        DeleteSellerCommandHandler handler = new(
            mockUserRepository.Object,
            mockUnitOfWork.Object);

        DeleteSellerCommand request = new(It.IsAny<Guid>());

        var deleteSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(deleteSellerResult.IsError);
        Assert.Equal(new Deleted(), deleteSellerResult);
    }
}
