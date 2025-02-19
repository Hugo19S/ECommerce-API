using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class SellerRespository(ECommerceDbContext dbContext) : ISellerRepository
{
    public async Task AddSeller(Seller seller, CancellationToken cancellationToken)
    {
        await dbContext.Seller.AddAsync(seller, cancellationToken);
    }

    public async Task DeleteSeller(Guid sellerId, CancellationToken cancellationToken)
    {
        await dbContext.Seller.Where(x => x.Id == sellerId)
                              .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<Seller>> GetAllSeller(CancellationToken cancellationToken)
    {
        return await dbContext.Seller.ToListAsync(cancellationToken);
    }

    public async Task<Seller?> GetSellerById(Guid sellerId, CancellationToken cancellationToken)
    {
        return await dbContext.Seller.FirstOrDefaultAsync(x => x.Id == sellerId, cancellationToken);
    }

    public Task<Seller?> GetSellerByName(string name, CancellationToken cancellationToken)
    {
        return dbContext.Seller.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }

    public async Task UpdateSeller(Guid sellerId, string name, CancellationToken cancellationToken)
    {
        await dbContext.Seller.Where(x => x.Id == sellerId)
                              .ExecuteUpdateAsync(p => p
                              .SetProperty(n => n.Name, name),
                              cancellationToken);
    }
}
