using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

internal interface IProductDiscountRepository
{
    Task<ErrorOr<Created>> AddProductDiscount(Guid productId, Guid createdBy, float discount, CancellationToken cancellationToken);
    Task<ErrorOr<ProductDiscount>> GetLatestProductDiscount(Guid productId, CancellationToken cancellationToken);
    Task<List<ProductDiscount>> GetAllProductDiscounts(Guid productId, CancellationToken cancellationToken);
}
