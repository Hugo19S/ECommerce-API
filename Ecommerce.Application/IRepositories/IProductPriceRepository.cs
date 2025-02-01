using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

internal interface IProductPriceRepository
{
    Task<ErrorOr<Created>> AddProductPrice(Guid productId, Guid createdBy, float price, CancellationToken cancellationToken);
    Task<ErrorOr<ProductPrice>> GetLatestProductPrice(Guid productId, CancellationToken cancellationToken);
    Task<List<ProductPrice>> GetAllProductPrices(Guid productId, CancellationToken cancellationToken);
}
