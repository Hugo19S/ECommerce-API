using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Queries.GetOrderHistory;

public record GetOrderHistoryQuery(Guid OrderId) : IRequest<ErrorOr<List<OrderStatusHistory>>>;

public class GetOrderHistoryQueryHandler(IOrderRepository repository)
    : IRequestHandler<GetOrderHistoryQuery, ErrorOr<List<OrderStatusHistory>>>
{
    public async Task<ErrorOr<List<OrderStatusHistory>>> Handle(GetOrderHistoryQuery request,
                                                                CancellationToken cancellationToken)
    {
        var order = await repository.GetOrderById(request.OrderId, cancellationToken);

        if (order == null)
        {
            return Error.NotFound("Order.NotFound", $"Order with id {request.OrderId} not found.");
        }

        return await repository.GetOrderHistory(request.OrderId, cancellationToken);
    }
}
