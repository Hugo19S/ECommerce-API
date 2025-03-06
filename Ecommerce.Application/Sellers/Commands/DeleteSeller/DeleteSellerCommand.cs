using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Sellers.Commands.DeleteSeller;

public record DeleteSellerCommand(Guid SellerId) : IRequest<ErrorOr<Deleted>>;

public class DeleteSellerCommandHandler(ISellerRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteSellerCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
    {
        var sellerExist = await repository.GetSellerById(request.SellerId, cancellationToken);

        if (sellerExist == null)
            return DomainErrors.NotFound("Seller", request.SellerId);

        await repository.DeleteSeller(request.SellerId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Deleted();
    }
}
