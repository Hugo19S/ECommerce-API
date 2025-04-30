using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetProduct;

public record GetProductCommand(Guid ProductId) : IRequest<ErrorOr<ProductDto>>;

public class GetProductCommandHandler(IProductRepository productRepository, ICacheRepository cache)
    : IRequestHandler<GetProductCommand, ErrorOr<ProductDto>>
{
    public async Task<ErrorOr<ProductDto>> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var product = await cache.GetCacheValueAsync<ProductDto>($"{request.ProductId}", cancellationToken);

        if (product != null)
            return product;

        product = await productRepository.GetProductById(request.ProductId, cancellationToken);

        if (product == null) 
            return DomainErrors.NotFound("Product", request.ProductId);

        await cache.SetCacheValue($"{request.ProductId}", product, cancellationToken);

        return product;
    }
}
