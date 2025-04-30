using Ecommerce.Application.Carts.Queries.GetPrudctsCart;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Moq;

namespace Ecommerce.Tests.CartsTest.Queries;

public class GetPrudctsCartQueryTest
{
    [Fact]
    public async void GetProductCartQery_Return_User_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockCartRepository = new Mock<ICartRepository>();

        GetPrudctsCartQueryHandler handler = new(mockUserRepository.Object,
                                                      mockCartRepository.Object);

        GetPrudctsCartQuery request = new(It.IsAny<Guid>());

        var createProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCartResult.IsError);
        Assert.Equal(DomainErrors.NotFound("User", request.UserId),
                                    createProductCartResult.FirstError);
    }

    [Fact]
    public async void GetProductCartQuery_Return_Cart_NotFound()
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

        GetPrudctsCartQueryHandler handler = new(
            mockUserRepository.Object,
            mockCartRepository.Object);

        GetPrudctsCartQuery request = new(It.IsAny<Guid>());

        var createProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCartResult.IsError);
        Assert.Equal(DomainErrors.Generic("User", "Cart"),
                                    createProductCartResult.FirstError);
    }

    [Fact]
    public async void GetProductCartCommand_Return_Product_In_The_Cart()
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

        List<CartDto> cartDto = [
            new CartDto
            {
                Id = Guid.NewGuid(),
                CartId = Guid.NewGuid(),
                Quantity = 2,
                Product = []
            }];

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository.Setup(x => x.GetUserById(It.IsAny<Guid>(), CancellationToken.None))
                          .ReturnsAsync(user);

        var mockCartRepository = new Mock<ICartRepository>();
        mockCartRepository.Setup(x => x.GetCartByUserId(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(cart);
        mockCartRepository.Setup(x => x.GetProductsCart(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(cartDto);

        GetPrudctsCartQueryHandler handler = new(
            mockUserRepository.Object,
            mockCartRepository.Object);

        GetPrudctsCartQuery request = new(It.IsAny<Guid>());

        var createProductCartResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createProductCartResult.IsError);
        Assert.Equal(cartDto, createProductCartResult);
    }
}
