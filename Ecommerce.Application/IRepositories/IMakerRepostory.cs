using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IMakerRepostory
{
    Task AddMaker(Maker maker, CancellationToken cancellationToken);
    Task<Maker?> GetMakerById(Guid makerId, CancellationToken cancellationToken);
    Task<Maker?> GetMakerByName(string name, CancellationToken cancellationToken);
    Task<List<Maker>> GetAllMaker(CancellationToken cancellationToken);
    Task UpdateMaker(Guid makerId, string name, CancellationToken cancellationToken);
    Task DeleteMaker(Guid makerId, CancellationToken cancellationToken);
}
