using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Carts.Commands.CreateProductCart;

public record CreateProductCartCommand(Guid UserId, Guid ProductId, int Quanity) : IRequest<ErrorOr<Created>>;

public class CreateProductCartCommandHandler(IUserRepository userRepository,
                                             ICartRepository cartRepository,
                                             IProductRepository productRepository,
                                             IUnitOfWork unitOfWork)
    : IRequestHandler<CreateProductCartCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateProductCartCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.UserId, cancellationToken);

        if (user == null)
            return DomainErrors.NotFound("User", request.UserId);
        
        var cart = await cartRepository.GetCartByUserId(request.UserId, cancellationToken);

        if (cart == null)
            return DomainErrors.Generic("User", "Cart");

        var product = await productRepository.GetProductById(request.ProductId, cancellationToken);

        if (product == null)
            return DomainErrors.NotFound("Product", request.ProductId);

        var cartItem = new CartItems
        {
            Id = Guid.NewGuid(),
            CartId = cart.Id,
            ProductId = request.ProductId,
            Quantity = request.Quanity
        };

        await cartRepository.AddProductCart(cartItem, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
