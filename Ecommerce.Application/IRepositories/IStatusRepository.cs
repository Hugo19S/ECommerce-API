using ErrorOr;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

internal interface IStatusRepository
{
    Task<ErrorOr<Created>> AddStatus(string name, string type, CancellationToken cancellationToken);
    Task<ErrorOr<Status>> GetStatusById(Guid statusId, CancellationToken cancellationToken);
    Task<List<Status>> GetAllStatus(CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateStatus(string name, string type, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteStatus(Guid statusId, CancellationToken cancellationToken);
}
