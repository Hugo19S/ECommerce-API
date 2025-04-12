using Ecommerce.Application.Carts.Commands.UpdateProductCart;
using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.CartsTest.Commands;

public class UpdateProductCartCommandTest
{
    [Fact]
    public async void UpdateProductCartCommand_Return_Cart_NotFound()
    {
        var mockCartRepository = new Mock<ICartRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        UpdateProductCartCommandHandler handler = new(mockCartRepository.Object,
                                                      mockProductRepository.Object,
                                                      mockUnitOfWork.Object);

        UpdateProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>());

        var updateProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateProductCartResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Cart", request.CartId),
                                    updateProductCartResult.FirstError);
    }

    [Fact]
    public async void UpdateProductCartCommand_Return_Product_NotFound()
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

        UpdateProductCartCommandHandler handler = new(
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        UpdateProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>());

        var updateProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateProductCartResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Product", request.ProductId),
                                    updateProductCartResult.FirstError);
    }


    [Fact]
    public async void UpdateProductCartCommand_Return_Product_NotFounded_In_Cart()
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

        UpdateProductCartCommandHandler handler = new(
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        UpdateProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>());

        var updateProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateProductCartResult.IsError);
        Assert.Equal(DomainErrors.Generic("Cart", "Product"),
                                    updateProductCartResult.FirstError);
    }

    [Fact]
    public async void UpdateProductCartCommand_Return_Product_Updated_From_Cart()
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

        UpdateProductCartCommandHandler handler = new(
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        UpdateProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>());

        var updateProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(updateProductCartResult.IsError);
        Assert.Equal(new Updated(), updateProductCartResult);
    }

}
