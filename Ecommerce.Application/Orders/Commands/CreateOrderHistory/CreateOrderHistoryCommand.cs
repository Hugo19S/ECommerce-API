﻿using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Commands.CreateOrderHistory;

public record CreateOrderHistoryCommand(Guid OrderId, Guid StatusId, string? Note) : IRequest<ErrorOr<Created>>;

public class CreateOrderHistoryCommandHandler(IOrderRepository orderRepository,
                                              IStatusRepository statusRepository,
                                              IUnitOfWork unitOfWork)
    : IRequestHandler<CreateOrderHistoryCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateOrderHistoryCommand request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetOrderById(request.OrderId, cancellationToken);

        if (order == null)
            return DomainErrors.NotFound("Order", request.OrderId);
        
        var status = await statusRepository.GetStatusById(request.StatusId, cancellationToken);

        if (status == null)
            return DomainErrors.NotFound("Status", request.StatusId);

        var orderHistory = new OrderStatusHistory
        {
            Id = Guid.NewGuid(),
            OrderId = order.Id,
            StatusId = status.Id,
            Note = request.Note,
            CreatedAt = DateTimeOffset.UtcNow,
        };

        await orderRepository.AddOrderHistory(orderHistory, cancellationToken);
        await orderRepository.UpdateOrder(order.Id, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
