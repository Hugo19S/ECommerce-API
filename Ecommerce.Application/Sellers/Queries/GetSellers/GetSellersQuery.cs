using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Sellers.Queries.GetSellers;

public record GetSellersQuery() : IRequest<ErrorOr<List<Seller>>>;

public class GetSellersQueryHandler(ISellerRepository repository) : IRequestHandler<GetSellersQuery, ErrorOr<List<Seller>>>
{
    public async Task<ErrorOr<List<Seller>>> Handle(GetSellersQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllSeller(cancellationToken);
    }
}
