using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Queries.GetUserOrders;

public record GetUserOrdersQuery(Guid UserId) : IRequest<ErrorOr<List<Order>>>;

public class GetUserOrdersQueryHandler(IOrderRepository orderRepository, IUserRepository userRepository)
    : IRequestHandler<GetUserOrdersQuery, ErrorOr<List<Order>>>
{
    public async Task<ErrorOr<List<Order>>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.UserId, cancellationToken);

        if (user == null)
        {
            return Error.NotFound("User.NotFound", $"User with id {request.UserId} not found.");
        }

        return await orderRepository.GetUserOrders(request.UserId, cancellationToken);
    }
}