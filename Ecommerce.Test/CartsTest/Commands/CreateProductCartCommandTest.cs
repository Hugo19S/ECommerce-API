using Ecommerce.Application.Carts.Commands.CreateProductCart;
using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.CartsTest.Commands;

public class CreateProductCartCommandTest
{
    [Fact]
    public async void CreateProductCartCommand_Return_User_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockCartRepository = new Mock<ICartRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateProductCartCommandHandler handler = new(mockUserRepository.Object,
                                                      mockCartRepository.Object,
                                                      mockProductRepository.Object,
                                                      mockUnitOfWork.Object);

        CreateProductCartCommand request = new(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<int>());

        var createProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCartResult.IsError);
        Assert.Equal(DomainErrors.NotFound("User", request.UserId),
                                    createProductCartResult.FirstError);
    }
    
    [Fact]
    public async void CreateProductCartCommand_Return_Cart_NotFound()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "email@gmail.com",
            Password = BCrypt.Net.BCrypt.HashPassword("Password"),
            PhoneNumber = "PhoneNumber",
            Address = "Address",
            CreatedAt = DateTime.UtcNow
        };

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(user);

        var mockCartRepository = new Mock<ICartRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateProductCartCommandHandler handler = new(
            mockUserRepository.Object,
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        CreateProductCartCommand request = new(user.Id, It.IsAny<Guid>(), It.IsAny<int>());

        var createProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCartResult.IsError);
        Assert.Equal(DomainErrors.Generic("User", "Cart"),
                                    createProductCartResult.FirstError);
    }

    [Fact]
    public async void CreateProductCartCommand_Return_Product_NotFound()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "email@gmail.com",
            Password = BCrypt.Net.BCrypt.HashPassword("Password"),
            PhoneNumber = "PhoneNumber",
            Address = "Address",
            CreatedAt = DateTime.UtcNow
        };

        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            UserId = user.Id
        };

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), CancellationToken.None)).ReturnsAsync(user);

        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(x => x.GetCartByUserId(It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(cart);

        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateProductCartCommandHandler handler = new(
            mockUserRepository.Object,
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        CreateProductCartCommand request = new(user.Id, It.IsAny<Guid>(), It.IsAny<int>());

        var createProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCartResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Product", request.ProductId),
                                    createProductCartResult.FirstError);
    }
    
    [Fact]
    public async void CreateProductCartCommand_Return_Product_Add_To_Cart()
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "FirstName",
            LastName = "LastName",
            Email = "email@gmail.com",
            Password = BCrypt.Net.BCrypt.HashPassword("Password"),
            PhoneNumber = "PhoneNumber",
            Address = "Address",
            CreatedAt = DateTime.UtcNow
        };

        var cart = new Cart
        {
            Id = Guid.NewGuid(),
            UserId = user.Id
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

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), CancellationToken.None))
                          .ReturnsAsync(user);

        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(x => x.GetCartByUserId(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(cart);

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository.Setup(x => x.GetProductById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                             .ReturnsAsync(product);

        var mockUnitOfWork = new Mock<IUnitOfWork>();

        CreateProductCartCommandHandler handler = new(
            mockUserRepository.Object,
            mockCartRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWork.Object);

        CreateProductCartCommand request = new(user.Id, product.Id, It.IsAny<int>());

        var createProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createProductCartResult.IsError);
        Assert.Equal(new Created(), createProductCartResult);
    }
}
