using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IProductRepository
{
    Task AddProduct(Product product, CancellationToken cancellationToken);
    Task AddProductImage(List<ProductImage> productImage, CancellationToken cancellationToken);
    Task AddProductPrice(ProductPrice productPrice, CancellationToken cancellationToken);
    Task AddProductDiscount(ProductDiscount productDiscount, CancellationToken cancellationToken);
    Task DeleteProduct(Guid productId, CancellationToken cancellationToken);
    Task DeleteProductImage(Guid imageId, CancellationToken cancellationToken);
    Task DeleteProductImages(Guid productId, CancellationToken cancellationToken);
    Task<ProductDto?> GetProductById(Guid productId, CancellationToken cancellationToken);
    Task<List<ProductDto>> GetAllProduct(CancellationToken cancellationToken);
    Task<ProductPrice?> GetProductPrice(Guid productId, CancellationToken cancellationToken);
    Task<List<ProductImage>> GetPoductImages(Guid productId, CancellationToken cancellationToken);
    Task<ProductDiscount?> GetProductDiscount(Guid productId, CancellationToken cancellationToken);
    Task UpdateProduct(Guid productId, ProductUpdateRequest productRequest, CancellationToken cancellationToken);
}
