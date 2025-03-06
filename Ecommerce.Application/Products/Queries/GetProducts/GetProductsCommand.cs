using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Products.Queries.GetProducts;

public record GetProductsCommand() : IRequest<ErrorOr<List<ProductDto>>>;

public class GetProductsCommandHandler(IProductRepository productRepository)
    : IRequestHandler<GetProductsCommand, ErrorOr<List<ProductDto>>>
{
    public async Task<ErrorOr<List<ProductDto>>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        return await productRepository.GetAllProduct(cancellationToken);
    }
}
