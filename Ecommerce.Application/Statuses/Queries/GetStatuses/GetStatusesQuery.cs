using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Statuses.Queries.GetStatuses;

public record GetStatusesQuery() : IRequest<ErrorOr<List<Status>>>;

public class GetStatusesQueryHandler(IStatusRepository repository)
    : IRequestHandler<GetStatusesQuery, ErrorOr<List<Status>>>
{
    public async Task<ErrorOr<List<Status>>> Handle(GetStatusesQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllStatus(cancellationToken);
    }
}
