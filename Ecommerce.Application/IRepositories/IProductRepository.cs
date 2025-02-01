using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

internal interface IProductRepository
{
    Task<ErrorOr<Created>> AddProduct(Product product, CancellationToken cancellationToken);
    Task<ErrorOr<Product>> GetProductById(Guid productId, CancellationToken cancellationToken);
    Task<List<Product>> GetAllProduct(CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateProduct(Product product, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteProduct(Guid productId, CancellationToken cancellationToken);
}
