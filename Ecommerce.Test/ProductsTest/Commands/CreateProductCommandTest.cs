using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Products.Commands.CreateProduct;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.ProductsTest.Commands;

public class CreateProductCommandTest
{
    [Fact]
    public async void CreateProductCommand_Return_User_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        var mockMakerRepostory = new Mock<IMakerRepostory>();
        var mockSellerRepository = new Mock<ISellerRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateProductCommandHandler handler = new(
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateProductCommand request = new(new ProductCreateRequest());

        var createProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("User", request.Product.CreatedBy), 
                     createProductCommandResult.FirstError);
    }
    
    [Fact]
    public async void CreateProductCommand_Return_SubCategory_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        var mockMakerRepostory = new Mock<IMakerRepostory>();
        var mockSellerRepository = new Mock<ISellerRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateProductCommandHandler handler = new(
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateProductCommand request = new(new ProductCreateRequest());

        var createProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("SubCategory", request.Product.CreatedBy),
                     createProductCommandResult.FirstError);
    }
    
    [Fact]
    public async void CreateProductCommand_Return_Maker_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository
            .Setup(x => x.GetSubCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubCategory());

        var mockMakerRepostory = new Mock<IMakerRepostory>();
        var mockSellerRepository = new Mock<ISellerRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateProductCommandHandler handler = new(
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateProductCommand request = new(new ProductCreateRequest());

        var createProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Maker", request.Product.CreatedBy),
                     createProductCommandResult.FirstError);
    }
    
    [Fact]
    public async void CreateProductCommand_Return_Seller_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository
            .Setup(x => x.GetSubCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubCategory());

        var mockMakerRepostory = new Mock<IMakerRepostory>();
        mockMakerRepostory
            .Setup(x => x.GetMakerById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Maker());

        var mockSellerRepository = new Mock<ISellerRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateProductCommandHandler handler = new(
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateProductCommand request = new(new ProductCreateRequest());

        var createProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(createProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Seller", request.Product.CreatedBy),
                     createProductCommandResult.FirstError);
    }
    
    [Fact]
    public async void CreateProductCommand_Return_Created()
    {
        ProductCreateRequest productCreateRequest = new();
        productCreateRequest.Images = ["Test1", "Test2"];

        List<ProductImage> images =
        [
            new ProductImage{
                Id = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                Uri = "Test",
                CreatedAt = DateTimeOffset.UtcNow
            }
        ];

        var mockUserRepository = new Mock<IUserRepository>();
        mockUserRepository
            .Setup(x => x.GetUserById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new User());

        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        mockSubCategoryRepository
            .Setup(x => x.GetSubCategoryById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new SubCategory());

        var mockMakerRepostory = new Mock<IMakerRepostory>();
        mockMakerRepostory
            .Setup(x => x.GetMakerById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Maker());

        var mockSellerRepository = new Mock<ISellerRepository>();
        mockSellerRepository
            .Setup(x => x.GetSellerById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Seller());

        var mockProductRepository = new Mock<IProductRepository>();
        mockProductRepository
            .Setup(x => x.AddProduct(new Product(), It.IsAny<CancellationToken>()));

        mockProductRepository
            .Setup(x => x.AddProductPrice(new ProductPrice(), It.IsAny<CancellationToken>()));

        mockProductRepository
            .Setup(x => x.AddProductImage(images, It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        CreateProductCommandHandler handler = new(
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object,
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object);

        CreateProductCommand request = new(productCreateRequest);

        var createProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(createProductCommandResult.IsError);
        Assert.Equal(new Created(), createProductCommandResult);
    }
}
