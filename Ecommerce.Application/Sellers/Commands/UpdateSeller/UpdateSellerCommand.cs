using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Sellers.Commands.UpdateSeller;

public record UpdateSellerCommand(Guid SellerId, string Name) : IRequest<ErrorOr<Updated>>;

public class UpdateSellerCommandHandler(ISellerRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateSellerCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
    {
        var sellerExist =await repository.GetSellerById(request.SellerId, cancellationToken);

        if (sellerExist == null)
            return Error.NotFound("Seller.NotFound", $"Seller with id {request.SellerId} not found.");

        var sellerWithSameName = await repository.GetSellerByName(request.Name, cancellationToken);

        if (sellerWithSameName != null)
            return Error.Conflict("Seller.Conflict", "There's already a seller with the same name!");

        await repository.UpdateSeller(request.SellerId, request.Name, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
