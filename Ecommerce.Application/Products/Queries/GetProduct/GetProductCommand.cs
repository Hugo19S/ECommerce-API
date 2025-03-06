using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetProduct;

public record GetProductCommand(Guid ProductId) : IRequest<ErrorOr<ProductDto>>;

public class GetProductCommandHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductCommand, ErrorOr<ProductDto>>
{
    public async Task<ErrorOr<ProductDto>> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductById(request.ProductId, cancellationToken);

        return product is not null ? product : DomainErrors.NotFound("Product", request.ProductId);
    }
}
