using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

public interface IProductImageRepository
{
    Task<ErrorOr<Created>> AddProductImage(string uri, string? description, CancellationToken cancellationToken);
    Task<ErrorOr<ProductImage>> GetProductImageById(Guid productImageId, CancellationToken cancellationToken);
    Task<List<ProductImage>> GetAllProductImage(Guid productId, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteProductImage(Guid productImageId, CancellationToken cancellationToken);
}
