using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Application.Products.Commands.UpdateProduct;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Moq;

namespace Ecommerce.Tests.ProductsTest.Commands;

public class UpdateProductCommandTest
{
    [Fact]
    public async void UpdateProductCommand_Return_User_NotFound()
    {
        var mockUserRepository = new Mock<IUserRepository>();
        var mockSubCategoryRepository = new Mock<ISubCategoryRepository>();
        var mockMakerRepostory = new Mock<IMakerRepostory>();
        var mockSellerRepository = new Mock<ISellerRepository>();
        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateProductCommandHandler handler = new(
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object,
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object);

        UpdateProductCommand request = new(It.IsAny<Guid>(), new ProductUpdateRequest());

        var updateProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("User", request.UpdateRequest.UpdatedBy),
                     updateProductCommandResult.FirstError);
    }

    [Fact]
    public async void UpdateProductCommand_Return_SubCategory_NotFound()
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

        UpdateProductCommandHandler handler = new(
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object,
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object);

        UpdateProductCommand request = new(It.IsAny<Guid>(), new ProductUpdateRequest());

        var updateProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("SubCategory", request.UpdateRequest.SubCategoryId),
                     updateProductCommandResult.FirstError);
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

        UpdateProductCommandHandler handler = new(
        mockProductRepository.Object,
        mockUnitOfWorkRepository.Object,
        mockUserRepository.Object,
        mockSubCategoryRepository.Object,
        mockMakerRepostory.Object,
        mockSellerRepository.Object);

        UpdateProductCommand request = new(It.IsAny<Guid>(), new ProductUpdateRequest());

        var updateProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Maker", request.UpdateRequest.MakerId),
                     updateProductCommandResult.FirstError);
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

        UpdateProductCommandHandler handler = new(
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object,
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object);

        UpdateProductCommand request = new(It.IsAny<Guid>(), new ProductUpdateRequest());

        var updateProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Seller", request.UpdateRequest.SellerId),
                     updateProductCommandResult.FirstError);
    }

    [Fact]
    public async void CreateProductCommand_Return_Product_NotFound()
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
        mockSellerRepository
            .Setup(x => x.GetSellerById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Seller());

        var mockProductRepository = new Mock<IProductRepository>();
        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateProductCommandHandler handler = new(
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object,
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object);

        UpdateProductCommand request = new(It.IsAny<Guid>(), new ProductUpdateRequest());

        var updateProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.True(updateProductCommandResult.IsError);
        Assert.Equal(DomainErrors.NotFound("Product", request.ProductId),
                     updateProductCommandResult.FirstError);
    }

    [Fact]
    public async void CreateProductCommand_Return_Updated()
    {
        ProductUpdateRequest productCreateRequest = new();
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
        mockProductRepository.Setup(x => x.GetProductById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ProductDto());

        mockProductRepository
            .Setup(x => x.UpdateProduct(It.IsAny<Guid>(), new ProductUpdateRequest(), It.IsAny<CancellationToken>()));
        
        mockProductRepository
            .Setup(x => x.DeleteProductImages(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

        mockProductRepository
            .Setup(x => x.AddProductImage(images, It.IsAny<CancellationToken>()));

        var mockUnitOfWorkRepository = new Mock<IUnitOfWork>();

        UpdateProductCommandHandler handler = new(
            mockProductRepository.Object,
            mockUnitOfWorkRepository.Object,
            mockUserRepository.Object,
            mockSubCategoryRepository.Object,
            mockMakerRepostory.Object,
            mockSellerRepository.Object);

        UpdateProductCommand request = new(It.IsAny<Guid>(), productCreateRequest);

        var updateProductCommandResult = await handler.Handle(request, CancellationToken.None);

        Assert.False(updateProductCommandResult.IsError);
        Assert.Equal(new Updated(), updateProductCommandResult);
    }
}
