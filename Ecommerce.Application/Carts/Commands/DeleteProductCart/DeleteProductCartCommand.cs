using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Carts.Commands.DeleteProductCart;

public record DeleteProductCartCommand(Guid CartId, Guid ProductId) : IRequest<ErrorOr<Deleted>>;

public class DeleteProductCartCommandHandler(ICartRepository cartRepository,
                                             IProductRepository productRepository,
                                             IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteProductCartCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteProductCartCommand request, CancellationToken cancellationToken)
    {        
        var cart = await cartRepository.GetCartById(request.CartId, cancellationToken);

        if (cart == null)
            return DomainErrors.NotFound("Cart", request.CartId);

        var product = await productRepository.GetProductById(request.ProductId, cancellationToken);

        if (product == null)
            return DomainErrors.NotFound("Product", request.ProductId);

        var productCart = await cartRepository.GetProductCart(cart.Id, request.ProductId, cancellationToken);
        
        if (productCart == null)
            return DomainErrors.Generic("Cart", "Product");

        await cartRepository.DeleteProductCart(cart.Id, request.ProductId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Deleted();
    }
}
