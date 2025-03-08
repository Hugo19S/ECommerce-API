using AutoMapper;
using Ecommerce.Application.Orders.Commands.CreateOrder;
using Ecommerce.Application.Orders.Commands.CreateOrderHistory;
using Ecommerce.Application.Orders.Queries.GetOrder;
using Ecommerce.Application.Orders.Queries.GetOrderHistory;
using Ecommerce.Application.Orders.Queries.GetUserOrders;
using Ecommerce.Service.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Service.Controllers;

[Route("api/[controller]")]
public class OrderController(ISender sender, IMapper mapper) : ApiController
{
    [HttpGet("{orderId:guid}")]
    public async Task<ActionResult> GetOrder(Guid orderId, CancellationToken cancellationToken)
    {
        var order = await sender.Send(new GetOrderQuery(orderId), cancellationToken);

        return order.Match(v => Ok(mapper.Map<OrderResponse>(v)), Problem);
    }
    
    [HttpGet("UserOrders/{userId:guid}")]
    public async Task<ActionResult> GetUserOrders(Guid userId, CancellationToken cancellationToken)
    {
        var order = await sender.Send(new GetUserOrdersQuery(userId), cancellationToken);

        return order.Match(v => Ok(mapper.Map<List<OrderResponse>>(v)), Problem);
    }
    
    [HttpGet("OrderHistory/{orderId:guid}")]
    public async Task<ActionResult> GetOrderHistory(Guid orderId, CancellationToken cancellationToken)
    {
        var order = await sender.Send(new GetOrderHistoryQuery(orderId), cancellationToken);

        return order.Match(v => Ok(mapper.Map<List<OrderHistoryResponse>>(v)), Problem);
    }

    [HttpPost("{userId:guid}")]
    public async Task<ActionResult> CreateOrder(Guid userId, 
                                                [FromBody] CreateOrderRequest orderRequest,
                                                CancellationToken cancellationToken)
    {
        var orderCreatedOr = await sender.Send(new CreateOrderCommand(userId,
                                                                      orderRequest.Value,
                                                                      orderRequest.OrderItems),
                                                                      cancellationToken);

        return orderCreatedOr.Match(v => Ok(v), Problem);
    }
    
    [HttpPost("OrderHistory/{orderId}/{statusId}")]
    public async Task<ActionResult> CreateOrderHistory(Guid orderId, Guid statusId,
                                                       [FromBody] CreateOrderHistoryRequest orderHistoryRequest,
                                                       CancellationToken cancellationToken)
    {
        var orderHistoryCreatedOr = await sender.Send(new CreateOrderHistoryCommand(orderId, statusId,
                                                                                    orderHistoryRequest.Note),
                                                                                    cancellationToken);

        return orderHistoryCreatedOr.Match(v => Ok(v), Problem);
    }
}
