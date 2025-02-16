using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Makers.Queries.GetMakers;

public record GetMakersQuery() : IRequest<ErrorOr<List<Maker>>>;
public class GetMakersQueryHandler(IMakerRepostory repostory) : IRequestHandler<GetMakersQuery, ErrorOr<List<Maker>>>
{
    public async Task<ErrorOr<List<Maker>>> Handle(GetMakersQuery request, CancellationToken cancellationToken)
    {
        return await repostory.GetAllMaker(cancellationToken);
    }
}
