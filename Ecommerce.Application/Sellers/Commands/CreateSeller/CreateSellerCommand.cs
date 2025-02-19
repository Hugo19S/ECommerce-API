using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Sellers.Commands.CreateSeller;

public record CreateSellerCommand(string Name) : IRequest<ErrorOr<Created>>;

public class CreateSellerCommandHandler(ISellerRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateSellerCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateSellerCommand request, CancellationToken cancellationToken)
    {
        var sellerWithSameName = await repository.GetSellerByName(request.Name, cancellationToken);

        if (sellerWithSameName != null)
        {
            return Error.Conflict("Seller.Conflict", "There's already a seller with the same name!");
        }

        var newSeller = new Seller
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await repository.AddSeller(newSeller, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
