using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface ICartRepository
{
    Task AddProductCart(CartItems cartItems, CancellationToken cancellationToken);
    Task<CartItems?> GetProductCart(Guid cartId, Guid productId, CancellationToken cancellationToken);
    Task<List<CartDto>> GetProductsCart(Guid cartId, CancellationToken cancellationToken);
    Task<Cart?> GetCartByUserId(Guid userId, CancellationToken cancellationToken);
    Task<Cart?> GetCartById(Guid cartId, CancellationToken cancellationToken);
    Task UpdateProductCart(Guid cartId, Guid productId, int quantity, CancellationToken cancellationToken);
    Task DeleteProductCart(Guid cartId, Guid productId, CancellationToken cancellationToken);
}
