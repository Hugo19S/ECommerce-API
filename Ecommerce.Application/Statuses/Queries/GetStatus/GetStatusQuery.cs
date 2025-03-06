using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Statuses.Queries.GetStatus;

public record GetStatusQuery(Guid StatusId) : IRequest<ErrorOr<Status>>;

public class GetStatusQueryHandler(IStatusRepository statusRepository) : IRequestHandler<GetStatusQuery, ErrorOr<Status>>
{
    public async Task<ErrorOr<Status>> Handle(GetStatusQuery request, CancellationToken cancellationToken)
    {
        var statusOr = await statusRepository.GetStatusById(request.StatusId, cancellationToken);

        if (statusOr == null) 
            return DomainErrors.NotFound("Status", request.StatusId);

        return statusOr;
    }
}
