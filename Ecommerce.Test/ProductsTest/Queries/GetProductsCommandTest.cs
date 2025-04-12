using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Products.Queries.GetProducts;
using Ecommerce.Domain.Common;
using Moq;

namespace Ecommerce.Tests.ProductsTest.Queries;

public class GetProductsCommandTest
{
    [Fact]
    public async void GetProductsCommand_Return_Product_List()
    {
        List<ProductDto> products = new();

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(x => x.GetAllProduct(It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);

        GetProductsCommandHandler handler = new(
            mockProductRepository.Object);

        GetProductsCommand request = new();

        var getProductsCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(getProductsCommandResult.IsError);
        Assert.Equal(products, getProductsCommandResult);
    }
}
