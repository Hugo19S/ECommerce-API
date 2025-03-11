using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class MakerRepository(ECommerceDbContext dbContext) : IMakerRepostory
{
    public async Task AddMaker(Maker maker, CancellationToken cancellationToken)
    {
        await dbContext.Maker.AddAsync(maker, cancellationToken);
    }

    public async Task DeleteMaker(Guid makerId, CancellationToken cancellationToken)
    {
        await dbContext.Maker.Where(x => x.Id == makerId)
                             .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<Maker>> GetAllMaker(CancellationToken cancellationToken)
    {
        return await dbContext.Maker.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<Maker?> GetMakerById(Guid makerId, CancellationToken cancellationToken)
    {
        return await dbContext.Maker.AsNoTracking().FirstOrDefaultAsync(x=> x.Id == makerId, cancellationToken);
    }

    public async Task<Maker?> GetMakerByName(string name, CancellationToken cancellationToken)
    {
        return await dbContext.Maker.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }

    public async Task UpdateMaker(Guid makerId, string name, CancellationToken cancellationToken)
    {
        await dbContext.Maker.Where(x => x.Id == makerId)
                             .ExecuteUpdateAsync(p => p
                             .SetProperty(n => n.Name, name)
                             .SetProperty(n => n.UpdatedAt, DateTimeOffset.UtcNow),
                             cancellationToken);
    }
}
