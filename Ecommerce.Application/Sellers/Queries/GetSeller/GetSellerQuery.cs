using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Sellers.Queries.GetSeller;

public record GetSellerQuery(Guid SellerId) : IRequest<ErrorOr<Seller>>;

public class GetSellerQueryHandler(ISellerRepository repository)
    : IRequestHandler<GetSellerQuery, ErrorOr<Seller>>
{
    public async Task<ErrorOr<Seller>> Handle(GetSellerQuery request, CancellationToken cancellationToken)
    {
        var seller = await repository.GetSellerById(request.SellerId, cancellationToken);

        if (seller == null)
            return DomainErrors.NotFound("Seller", request.SellerId);

        return seller;
    }
}
