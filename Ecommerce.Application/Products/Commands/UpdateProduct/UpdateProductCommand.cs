using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand(Guid ProductId, ProductUpdateRequest UpdateRequest) : IRequest<ErrorOr<Updated>>;

public class UpdateProductCommandHandler(IProductRepository repository, 
                                         IUnitOfWork unitOfWork,
                                         IUserRepository userRepository,
                                         ISubCategoryRepository subCategoryRepository,
                                         IMakerRepostory makerRepostory,
                                         ISellerRepository sellerRepository)
    : IRequestHandler<UpdateProductCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.UpdateRequest.UpdatedBy, cancellationToken);

        if (user == null)
            return DomainErrors.NotFound("User", request.UpdateRequest.UpdatedBy);

        var subCategory = await subCategoryRepository.GetSubCategoryById(request.UpdateRequest.SubCategoryId,
                                                                         cancellationToken);

        if (subCategory == null)
            return DomainErrors.NotFound("SubCategory", request.UpdateRequest.SubCategoryId);

        var maker = await makerRepostory.GetMakerById(request.UpdateRequest.MakerId, cancellationToken);

        if (maker == null)
            return DomainErrors.NotFound("Maker", request.UpdateRequest.MakerId);

        var seller = await sellerRepository.GetSellerById(request.UpdateRequest.SellerId, cancellationToken);

        if (seller == null)
            return DomainErrors.NotFound("Seller", request.UpdateRequest.SellerId);

        var product = await repository.GetProductById(request.ProductId, cancellationToken);

        if (product == null)
            return DomainErrors.NotFound("Product", request.ProductId);

        var lastPrice = await repository.GetProductPrice(request.ProductId, cancellationToken);

        if (lastPrice is null || lastPrice.Price != request.UpdateRequest.Price)
        {
            var price = new ProductPrice
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                CreatedBy = request.UpdateRequest.UpdatedBy,
                Price = request.UpdateRequest.Price,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await repository.AddProductPrice(price, cancellationToken);
        }

        var productDiscount = await repository.GetProductDiscount(request.ProductId, cancellationToken);

        if (productDiscount is null || productDiscount.Discount != request.UpdateRequest.Discount)
        {
            var discount = new ProductDiscount
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                CreatedBy = request.UpdateRequest.UpdatedBy,
                Discount = request.UpdateRequest.Discount,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await repository.AddProductDiscount(discount, cancellationToken);
        }

        await repository.UpdateProduct(request.ProductId, request.UpdateRequest, cancellationToken);

        await repository.DeleteProductImages(request.ProductId, cancellationToken);

        var imageList = new List<ProductImage>();

        foreach (var item in request.UpdateRequest.Images)
        {
            var image = new ProductImage
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                Uri = item,
                CreatedAt = DateTimeOffset.UtcNow
            };

            imageList.Add(image);
        }

        await repository.AddProductImage(imageList, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
