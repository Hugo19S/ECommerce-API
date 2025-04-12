using Ecommerce.Application.Carts.Commands.DeleteProductCart;
using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.CartsTest.Commands;

public class DeleteProductCartCommandTest
{
    [Fact]
    public async void DeleteProductCartCommand_Return_Cart_NotFound()
    {
        var mockCartRepository = new Mock<ICartRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        DeleteProductCartCommandHandler handler = new(mockCartRepository.Object,
                                                      mockProductRepository.Object,
                                                      mockUnitOfWork.Object);

        DeleteProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>());

        var deleteProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(deleteProductCartResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Cart", request.CartId),
                                    deleteProductCartResult.FirstError);
    }

    [Fact]
    public async void DeleteProductCartCommand_Return_Product_NotFound()
    {
        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            UserId = Guid.NewGuid()
        };

        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(x => x.GetCartById(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(cart);

        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        DeleteProductCartCommandHandler handler = new(
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        DeleteProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>());

        var deleteProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(deleteProductCartResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Product", request.ProductId),
                                    deleteProductCartResult.FirstError);
    }

    [Fact]
    public async void DeleteProductCartCommand_Return_Product_NotFounded_In_Cart()
    {
        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            UserId = Guid.NewGuid()
        };

        var product = new ProductDto
        {
            Id = It.IsAny<Guid>(),
            SubCategory = "SubCategory",
            Maker = "Maker",
            Seller = "Seller",
            Name = "Name",
            Sku = "Sku",
            Description = "Description",
            Model = "Model",
            IsActive = true,
            Price = 15,
            Discount = 0,
            Images = []
        };

        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(x => x.GetCartById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(cart);

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(x => x.GetProductById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                             .ReturnsAsync(product);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        DeleteProductCartCommandHandler handler = new(
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        DeleteProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>());

        var deleteProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(deleteProductCartResult.IsError);
        Assert.Equal(DomainErrors.Generic("Cart", "Product"),
                                    deleteProductCartResult.FirstError);
    }

    [Fact]
    public async void DeleteProductCartCommand_Return_Product_Deleted_From_Cart()
    {
        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            UserId = Guid.NewGuid()
        };

        var product = new ProductDto
        {
            Id = It.IsAny<Guid>(),
            SubCategory = "SubCategory",
            Maker = "Maker",
            Seller = "Seller",
            Name = "Name",
            Sku = "Sku",
            Description = "Description",
            Model = "Model",
            IsActive = true,
            Price = 15,
            Discount = 0,
            Images = []
        };

        var cartItems = new CartItems
        {
            Id = Guid.NewGuid(),
            CartId = Guid.NewGuid(),
            ProductId = Guid.NewGuid(),
            Quantity = 1
        };

        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(x => x.GetCartById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(cart);

        mockCartRepository.Setup(x => x.GetProductCart(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(cartItems);

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(x => x.GetProductById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                             .ReturnsAsync(product);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        DeleteProductCartCommandHandler handler = new(
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        DeleteProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>());

        var deleteProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(deleteProductCartResult.IsError);
        Assert.Equal(new Deleted(), deleteProductCartResult);
    }
}
