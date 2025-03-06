using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Makers.Queries.GetMaker;

public record GetMakerQuery(Guid MakerId) : IRequest<ErrorOr<Maker>>;

public class GetMakerQueryHandler(IMakerRepostory repostory)
    : IRequestHandler<GetMakerQuery, ErrorOr<Maker>>
{
    public async Task<ErrorOr<Maker>> Handle(GetMakerQuery request, CancellationToken cancellationToken)
    {
        var maker = await repostory.GetMakerById(request.MakerId, cancellationToken);

        if (maker == null)
            return DomainErrors.NotFound("Maker", request.MakerId);

        return maker;
    }
}
