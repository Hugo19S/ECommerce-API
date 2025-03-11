using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class CartRepository(ECommerceDbContext dbContext) : ICartRepository
{
    public async Task AddProductCart(CartItems cartItems, CancellationToken cancellationToken)
    {
        await dbContext.CartItems.AddAsync(cartItems, cancellationToken);
    }

    public async Task DeleteProductCart(Guid cartId, Guid productId, CancellationToken cancellationToken)
    {
        await dbContext.CartItems
                       .Where(x => x.CartId == cartId && x.ProductId == productId)
                       .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<Cart?> GetCartByUserId(Guid userId, CancellationToken cancellationToken)
    {
        return await dbContext.Cart
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
    }
    
    public async Task<Cart?> GetCartById(Guid cartId, CancellationToken cancellationToken)
    {
        return await dbContext.Cart
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == cartId, cancellationToken);
    }

    public async Task<CartItems?> GetProductCart(Guid cartId, Guid productId, CancellationToken cancellationToken)
    {
        return await dbContext.CartItems
                        .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.CartId == cartId && 
                                             x.ProductId == productId, 
                                             cancellationToken);
    }

    public async Task<List<CartDto>> GetProductsCart(Guid cartId, CancellationToken cancellationToken)
    {
        return await dbContext.CartItems
                        .AsNoTracking()
                        .IgnoreAutoIncludes()
                        .Select(x => new CartDto
                        {
                            Id = x.Id,
                            CartId = x.CartId,
                            Quantity = x.Quantity,
                            Product = dbContext.Product.
                                         AsNoTracking()
                                         .Where(e => e.Id == x.ProductId)
                                         .Select(p => new ProductDto
                                         {
                                             Id = p.Id,
                                             Name = p.Name,
                                             Sku = p.Sku,
                                             Description = p.Description,
                                             Model = p.Model,
                                             Seller = p.Seller.Name,
                                             Maker = p.Maker.Name,
                                             SubCategory = p.SubCategory.Name,
                                             IsActive = p.IsActive,
                                             Price = dbContext.ProductPrice
                                                         .AsNoTracking()
                                                         .Where(n => n.ProductId == p.Id)
                                                         .OrderByDescending(n => n.CreatedAt)
                                                         .Select(n => n.Price)
                                                         .FirstOrDefault(),
                                             Discount = dbContext.ProductDiscount
                                                         .AsNoTracking()
                                                         .Where(n => n.ProductId == p.Id)
                                                         .OrderByDescending(n => n.CreatedAt)
                                                         .Select(n => n.Discount)
                                                         .FirstOrDefault(),
                                             Images = dbContext.ProductImage.AsNoTracking()
                                             .Where(x => x.ProductId == p.Id)
                                                         .Select(x => new ImageDto { Id = x.Id, Uri = x.Uri })
                                                         .ToList()
                                         }).ToList()
                        })
                        .Where(x => x.CartId == cartId)
                        .ToListAsync(cancellationToken);
    }

    public async Task UpdateProductCart(Guid cartId, Guid productId, int quantity, CancellationToken cancellationToken)
    {
        await dbContext.CartItems
                       .Where(x => x.CartId == cartId && x.ProductId == productId)
                       .ExecuteUpdateAsync(p => p
                       .SetProperty(n => n.Quantity, quantity),
                       cancellationToken);
    }
}
