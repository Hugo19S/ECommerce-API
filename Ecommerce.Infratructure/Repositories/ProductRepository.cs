using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class ProductRepository(ECommerceDbContext dbContext) : IProductRepository
{
    public async Task AddProduct(Product product, CancellationToken cancellationToken)
    {
        await dbContext.Product.AddAsync(product, cancellationToken);
    }

    public async Task AddProductDiscount(ProductDiscount productDiscount, CancellationToken cancellationToken)
    {
        await dbContext.ProductDiscount.AddAsync(productDiscount, cancellationToken);
    }

    public async Task AddProductImage(List<ProductImage> productImage, CancellationToken cancellationToken)
    {
        await dbContext.ProductImage.AddRangeAsync(productImage, cancellationToken);
    }

    public async Task AddProductPrice(ProductPrice productPrice, CancellationToken cancellationToken)
    {
        await dbContext.ProductPrice.AddAsync(productPrice, cancellationToken);
    }

    public async Task DeleteProduct(Guid productId, CancellationToken cancellationToken)
    {
        await dbContext.Product.Where(x => x.Id == productId)
                               .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task DeleteProductImage(Guid imageId, CancellationToken cancellationToken)
    {
        await dbContext.ProductImage
                       .Where(x => x.Id == imageId)
                       .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task DeleteProductImages(Guid productId, CancellationToken cancellationToken)
    {
        await dbContext.ProductImage
                       .Where(x => x.ProductId == productId)
                       .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<ProductDto>> GetAllProduct(CancellationToken cancellationToken)
    {
        return await dbContext.Product
            .AsNoTracking()
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
                Images = dbContext.ProductImage.Where(x => x.ProductId == p.Id)
                                  .Select(x => new ImageDto { Id = x.Id, Uri = x.Uri })
                                  .ToList()
            }).ToListAsync(cancellationToken);
    }

    public async Task<List<ProductImage>> GetPoductImages(Guid productId, CancellationToken cancellationToken)
    {
        return await dbContext.ProductImage
                              .Where(x => x.ProductId == productId)
                              .ToListAsync(cancellationToken);
    }

    public async Task<ProductDto?> GetProductById(Guid productId, CancellationToken cancellationToken)
    {
        return await dbContext.Product
            .AsNoTracking()
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
                Images = dbContext.ProductImage.Where(x => x.ProductId == p.Id)
                                  .Select(x => new ImageDto { Id = x.Id, Uri = x.Uri })
                                  .ToList()
            }).FirstOrDefaultAsync(x => x.Id == productId, cancellationToken);
    }

    public async Task<ProductDiscount?> GetProductDiscount(Guid productId, CancellationToken cancellationToken)
    {
        return await dbContext.ProductDiscount
                              .Where(x => x.ProductId == productId)
                              .OrderByDescending(x => x.CreatedAt)
                              .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<ProductPrice?> GetProductPrice(Guid productId, CancellationToken cancellationToken)
    {
        return await dbContext.ProductPrice
                              .Where(x => x.ProductId == productId)
                              .OrderByDescending(x => x.CreatedAt)
                              .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateProduct(Guid productId, ProductUpdateRequest updateRequest, CancellationToken cancellationToken)
    {
        await dbContext.Product
                       .Where(x => x.Id == productId)
                       .ExecuteUpdateAsync(p => p
                       .SetProperty(n => n.UpdatedBy, updateRequest.UpdatedBy)
                       .SetProperty(n => n.SubCategoryId, updateRequest.SubCategoryId)
                       .SetProperty(n => n.MakerId, updateRequest.MakerId)
                       .SetProperty(n => n.SellerId, updateRequest.SellerId)
                       .SetProperty(n => n.Name, updateRequest.Name)
                       .SetProperty(n => n.Sku, updateRequest.Sku)
                       .SetProperty(n => n.Description, updateRequest.Description)
                       .SetProperty(n => n.Model, updateRequest.Model)
                       .SetProperty(n => n.IsActive, updateRequest.IsActive)
                       .SetProperty(n => n.UpdatedAt, DateTimeOffset.UtcNow),
                       cancellationToken);
    }
}
