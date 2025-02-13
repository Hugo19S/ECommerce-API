using ErrorOr;
using Ecommerce.Domain.Entities;
using MediatR;

namespace Ecommerce.Application.IRepositories;

public interface IStatusRepository
{
    Task AddStatus(Status status, CancellationToken cancellationToken);
    Task<Status?> GetStatusById(Guid statusId, CancellationToken cancellationToken);
    Task<Status?> GetStatusByName(string statusName, string statutypesName, CancellationToken cancellationToken);
    Task<List<Status>> GetAllStatus(CancellationToken cancellationToken);
    Task UpdateStatus(Guid statusId , string name , string type , string description, CancellationToken cancellationToken);
    Task DeleteStatus(Guid statusId, CancellationToken cancellationToken);
}
