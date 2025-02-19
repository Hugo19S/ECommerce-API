using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Sellers.Queries.GetSeller;

public record GetSellerCommand(Guid SellerId) : IRequest<ErrorOr<Seller>>;

public class GetSellerCommandHandler(ISellerRepository repository)
    : IRequestHandler<GetSellerCommand, ErrorOr<Seller>>
{
    public async Task<ErrorOr<Seller>> Handle(GetSellerCommand request, CancellationToken cancellationToken)
    {
        var seller = await repository.GetSellerById(request.SellerId, cancellationToken);

        if (seller == null)
        {
            return Error.NotFound("Seller.NotFound", $"Seller with id {request.SellerId} not found.");
        }

        return seller;
    }
}
