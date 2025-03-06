using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(ProductCreateRequest Product) : IRequest<ErrorOr<Created>>;

public class CreateProductCommandHandler(IUserRepository userRepository,
                                         ISubCategoryRepository subCategoryRepository,
                                         IMakerRepostory makerRepostory,
                                         ISellerRepository sellerRepository,
                                         IProductRepository productRepository,
                                         IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.Product.CreatedBy, cancellationToken);

        if (user == null)
            return DomainErrors.NotFound("User", request.Product.CreatedBy);

        var subCategory = await subCategoryRepository.GetSubCategoryById(request.Product.SubCategoryId, 
                                                                         cancellationToken);

        if (subCategory == null)
            return DomainErrors.NotFound("SubCategory", request.Product.SubCategoryId);

        var maker = await makerRepostory.GetMakerById(request.Product.MakerId, cancellationToken);

        if(maker == null)
            return DomainErrors.NotFound("Maker", request.Product.MakerId);

        var seller = await sellerRepository.GetSellerById(request.Product.SellerId, cancellationToken);

        if (seller == null)
            return DomainErrors.NotFound("Seller", request.Product.SellerId);

        var productId = Guid.NewGuid();

        var product = new Product
        {
            Id = productId,
            CreatedBy = request.Product.CreatedBy,
            SubCategoryId = request.Product.SubCategoryId,
            MakerId = request.Product.MakerId,
            SellerId = request.Product.SellerId,
            Name = request.Product.Name,
            Sku = request.Product.Sku,
            Description = request.Product.Description,
            Model = request.Product.Model,
            IsActive = true,
            CreatedAt = DateTimeOffset.UtcNow
        };

        var productPrice = new ProductPrice
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            CreatedBy = request.Product.CreatedBy,
            Price = request.Product.Price,
            CreatedAt = DateTimeOffset.UtcNow
        };

        var productImages = request.Product.Images.Select(image => new ProductImage
        {
            Id = Guid.NewGuid(),
            ProductId = productId,
            Uri = image,
            CreatedAt = DateTimeOffset.UtcNow
        }).ToList();

        await productRepository.AddProduct(product, cancellationToken);
        await productRepository.AddProductPrice(productPrice, cancellationToken);
        await productRepository.AddProductImage(productImages, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
