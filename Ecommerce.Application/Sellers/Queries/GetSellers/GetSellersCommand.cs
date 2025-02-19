using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Sellers.Queries.GetSellers;

public record GetSellersCommand() : IRequest<ErrorOr<List<Seller>>>;

public class GetSellersCommandHandler(ISellerRepository repository) : IRequestHandler<GetSellersCommand, ErrorOr<List<Seller>>>
{
    public async Task<ErrorOr<List<Seller>>> Handle(GetSellersCommand request, CancellationToken cancellationToken)
    {
        var sellers = await repository.GetAllSeller(cancellationToken);

        return sellers;
    }
}
