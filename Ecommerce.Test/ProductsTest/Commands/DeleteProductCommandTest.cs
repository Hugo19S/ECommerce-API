using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Products.Commands.DeleteProduct;
using Ecommerce.Domain.Common;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.ProductsTest.Commands;

public class DeleteProductCommandTest
{
    [Fact]
    public async void DeleteProductCommand_Return_NotFound() 
    {
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeleteProductCommandHandler handler = new(
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        DeleteProductCommand request = new(It.IsAny<Guid>());

        var deleteProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(deleteProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Product", request.ProductId),
                     deleteProductCommandResult.FirstError);
    }

    [Fact]
    public async void DeleteProductCommand_Return_Deleted() 
    {
        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(x => x.GetProductById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ProductDto());

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        DeleteProductCommandHandler handler = new(
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        DeleteProductCommand request = new(It.IsAny<Guid>());

        var deleteProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(deleteProductCommandResult.IsError);
        Assert.Equal(new Deleted(), deleteProductCommandResult);
    }
}
