﻿using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

public interface IOrderRepository
{
    // Order
    Task AddOrder(Order order, CancellationToken cancellationToken);
    Task<OrderDto?> GetOrderById(Guid orderId, CancellationToken cancellationToken);
    Task<List<OrderDto>> GetUserOrders(Guid userId, CancellationToken cancellationToken);
    Task UpdateOrder(Guid orderId, CancellationToken cancellationToken);

    // Order History
    Task AddOrderHistory(OrderStatusHistory orderStatusHistory, CancellationToken cancellationToken);
    Task<List<OrderStatusHistory>> GetOrderHistory(Guid orderId, CancellationToken cancellationToken);

    // Order Items
    Task AddOrderItems(OrderItems items, CancellationToken cancellationToken);
    Task<List<OrderItems>> GetOrderItems(Guid orderId, CancellationToken cancellationToken);
}
