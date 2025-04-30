using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetProducts;

public record GetProductsCommand(int Page, int Limit) : IRequest<ErrorOr<List<ProductDto>>>;

public class GetProductsCommandHandler(IProductRepository productRepository, ICacheRepository cache)
    : IRequestHandler<GetProductsCommand, ErrorOr<List<ProductDto>>>
{
    public async Task<ErrorOr<List<ProductDto>>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = $"Products{request.Page}_{request.Limit}";

        var products = await cache.GetCacheValueAsync<List<ProductDto>>(cacheKey, cancellationToken);

        if (products != null)
            return products;

        products = await productRepository.GetAllProduct(cancellationToken);

        await cache.SetCacheValue(cacheKey, products, cancellationToken);

        return products;
    }
}
