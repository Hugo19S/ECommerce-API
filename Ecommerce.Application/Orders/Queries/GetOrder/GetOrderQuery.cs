using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Queries.GetOrder;

public record GetOrderQuery(Guid OrderId) : IRequest<ErrorOr<Order>>;

public class GetOrderQueryHandler(IOrderRepository repository)
    : IRequestHandler<GetOrderQuery, ErrorOr<Order>>
{
    public async Task<ErrorOr<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await repository.GetOrderById(request.OrderId, cancellationToken);

        if (order == null)
        {
            return Error.NotFound("Order.NotFound", $"Order with id {request.OrderId} not found.");
        }

        return order;
    }
}
