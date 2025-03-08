using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Queries.GetOrder;

public record GetOrderQuery(Guid OrderId) : IRequest<ErrorOr<OrderDto>>;

public class GetOrderQueryHandler(IOrderRepository repository)
    : IRequestHandler<GetOrderQuery, ErrorOr<OrderDto>>
{
    public async Task<ErrorOr<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await repository.GetOrderById(request.OrderId, cancellationToken);

        return order is not null ? order : DomainErrors.NotFound("Order", request.OrderId);
    }
}
