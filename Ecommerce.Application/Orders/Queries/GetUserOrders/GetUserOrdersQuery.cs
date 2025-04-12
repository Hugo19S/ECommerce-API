using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Queries.GetUserOrders;

public record GetUserOrdersQuery(Guid UserId) : IRequest<ErrorOr<List<OrderDto>>>;

public class GetUserOrdersQueryHandler(IOrderRepository orderRepository, IUserRepository userRepository)
    : IRequestHandler<GetUserOrdersQuery, ErrorOr<List<OrderDto>>>
{
    public async Task<ErrorOr<List<OrderDto>>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.UserId, cancellationToken);

        if (user == null)
            return DomainErrors.NotFound("User", request.UserId);

        return await orderRepository.GetUserOrders(request.UserId, cancellationToken);
    }
}