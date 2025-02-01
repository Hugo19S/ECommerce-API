using ErrorOr;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

internal interface ICartRepository
{
    Task<ErrorOr<Created>> AddCart(Guid userId, Guid productId, int quantity, CancellationToken cancellationToken);
    Task<List<Cart>> GetAllCarts(Guid userId, CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateCart(Guid cartId, Guid productId, int quantity, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteCart(Guid cartId, CancellationToken cancellationToken);
}
