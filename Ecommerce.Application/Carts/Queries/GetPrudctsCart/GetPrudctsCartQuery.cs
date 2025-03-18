using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Carts.Queries.GetPrudctsCart;

public record GetPrudctsCartQuery(Guid UserId) : IRequest<ErrorOr<List<CartDto>>>;

public class GetPrudctsCartQueryHandler(IUserRepository userRepository,
                                        ICartRepository cartRepository) 
    : IRequestHandler<GetPrudctsCartQuery, ErrorOr<List<CartDto>>>
{
    public async Task<ErrorOr<List<CartDto>>> Handle(GetPrudctsCartQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.UserId, cancellationToken);
        if (user == null)
            return DomainErrors.NotFound("User", request.UserId);

        var cart = await cartRepository.GetCartByUserId(request.UserId, cancellationToken);
        if (cart == null)
            return DomainErrors.Generic("User", "Cart");

        return await cartRepository.GetProductsCart(cart.Id, cancellationToken);
    }
}
