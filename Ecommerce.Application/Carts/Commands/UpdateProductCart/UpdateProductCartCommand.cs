using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Carts.Commands.UpdateProductCart;

public record UpdateProductCartCommand(Guid CartId, Guid ProductId, int Quantity) : IRequest<ErrorOr<Updated>>;

public class UpdateProductCartCommandHandler(ICartRepository cartRepository,
                                             IProductRepository productRepository,
                                             IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateProductCartCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateProductCartCommand request, CancellationToken cancellationToken)
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

        await cartRepository.UpdateProductCart(request.CartId, request.ProductId, request.Quantity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
