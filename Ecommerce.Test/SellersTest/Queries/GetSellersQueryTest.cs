using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Sellers.Queries.GetSellers;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.SellersTest.Queries;

public class GetSellersQueryTest
{
    [Fact]
    public async void GetSellersQuery_Return_Seller_List()
    {
        List<Seller> list = 
        [
            new Seller
            {
                Id = Guid.NewGuid(),
                Name = "name",
                CreatedAt = DateTimeOffset.UtcNow
            }
        ];

        var mockUserRepository = new Mock<ISellerRepository>();
        mockUserRepository.Setup(x => x.GetAllSeller(CancellationToken.None))
                          .ReturnsAsync(list);

        GetSellersQueryHandler handler = new(mockUserRepository.Object);

        GetSellersQuery request = new();

        var getSellersResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(getSellersResult.IsError);
        Assert.Equal(list, getSellersResult);
    }
}
