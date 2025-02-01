using ErrorOr;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

interface IMakerRepostory
{
    Task<ErrorOr<Created>> AddMaker(string name, CancellationToken cancellationToken);
    Task<ErrorOr<Maker>> GetMakerById(Guid makerId, CancellationToken cancellationToken);
    Task<List<Maker>> GetAllMaker(CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateMaker(Guid makerId, string name, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteMaker(Guid makerId, CancellationToken cancellationToken);
}
