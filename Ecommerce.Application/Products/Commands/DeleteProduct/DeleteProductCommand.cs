using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(Guid ProductId) : IRequest<ErrorOr<Deleted>>;

public class DeleteProductCommandHandler(IProductRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await repository.GetProductById(request.ProductId, cancellationToken);

        if (product == null)
        {
            return DomainErrors.NotFound("Product", request.ProductId);
        }

        await repository.DeleteProduct(request.ProductId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Deleted();
    }
}
