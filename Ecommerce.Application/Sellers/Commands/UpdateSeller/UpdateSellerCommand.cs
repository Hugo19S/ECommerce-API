using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
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
            return DomainErrors.NotFound("Seller", request.SellerId);

        var sellerWithSameName = await repository.GetSellerByName(request.Name, cancellationToken);

        if (sellerWithSameName != null)
            return DomainErrors.Conflict("Seller");

        await repository.UpdateSeller(request.SellerId, request.Name, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
