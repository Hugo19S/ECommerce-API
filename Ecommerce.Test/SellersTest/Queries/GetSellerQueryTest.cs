using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Sellers.Queries.GetSeller;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.SellersTest.Queries;

public class GetSellerQueryTest
{
    [Fact]
    public async void GetSellerQuery_Return_NotFound()
    {
        var mockUserRepository = new Mock<ISellerRepository>();

        GetSellerQueryHandler handler = new(
            mockUserRepository.Object);

        GetSellerQuery request = new(It.IsAny<Guid>());

        var getSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(getSellerResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Seller", request.SellerId), getSellerResult.FirstError);
    }

    [Fact]
    public async void GetSellerQuery_Return_Seller()
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

        GetSellerQueryHandler handler = new(mockUserRepository.Object);

        GetSellerQuery request = new(It.IsAny<Guid>());

        var getSellerResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(getSellerResult.IsError);
        Assert.Equal(seller, getSellerResult);
    }
}
