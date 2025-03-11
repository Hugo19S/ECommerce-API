using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class StatusRepository(ECommerceDbContext dbContext) : IStatusRepository
{
    public async Task AddStatus(Status status, CancellationToken cancellationToken)
    {
        await dbContext.AddAsync(status, cancellationToken);
    }

    public async Task DeleteStatus(Guid statusId, CancellationToken cancellationToken)
    {
        await dbContext.Status.Where(x => x.Id == statusId).ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<Status>> GetAllStatus(CancellationToken cancellationToken)
    {
        return await dbContext.Status.OrderBy(x => x.Name).ToListAsync(cancellationToken);
    }

    public async Task<Status?> GetStatusById(Guid statusId, CancellationToken cancellationToken)
    {
        return await dbContext.Status.FirstOrDefaultAsync(x => x.Id == statusId, cancellationToken);
    }
    
    public async Task<Status?> GetStatusByName(string statusName, string type, CancellationToken cancellationToken)
    {
        return await dbContext.Status.FirstOrDefaultAsync(x => x.Name == statusName && x.Type == type, cancellationToken);
    }

    public async Task UpdateStatus(Guid statusId, string name, string type, string description, CancellationToken cancellationToken)
    {
        await dbContext.Status.Where(x => x.Id == statusId)
                              .ExecuteUpdateAsync(v => v
                              .SetProperty(p => p.Name, name)
                              .SetProperty(p => p.Type, type)
                              .SetProperty(p => p.Description, description), cancellationToken);
    }
}
