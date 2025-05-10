using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Products.Queries.GetProduct;
using Ecommerce.Domain.Common;
using Moq;

namespace Ecommerce.Tests.ProductsTest.Queries;

public class GetProductCommandTest
{
    [Fact]
    public async void GetProductCommand_Return_NotFound()
    {
        var mockProductRepository = new Mock<IProductRepository>();
        var mockCacheRepository = new Mock<ICacheRepository>();

        GetProductCommandHandler handler = new(mockProductRepository.Object, mockCacheRepository.Object);

        GetProductCommand request = new(It.IsAny<Guid>());

        var getProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(getProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Product", request.ProductId), getProductCommandResult.FirstError);
    }

    [Fact]
    public async void GetProductCommand_Return_Product()
    {
        ProductDto product = new() 
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Sku = "",
            Seller = "Test",
            Maker = "Test",
            SubCategory = "Test",
            IsActive = true,
            Price = 0,
            Discount = 0,
            Images = []
        };

        var mockProductRepository = new Mock<IProductRepository>();
        var mockCacheRepository = new Mock<ICacheRepository>();

        mockProductRepository.Setup(x => x.GetProductById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(product);

        GetProductCommandHandler handler = new(mockProductRepository.Object, mockCacheRepository.Object);

        GetProductCommand request = new(It.IsAny<Guid>());

        var getProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(getProductCommandResult.IsError);
        Assert.Equal(product, getProductCommandResult);
    }
}
