using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class OrderRepository(ECommerceDbContext dbContext) : IOrderRepository
{
    public async Task AddOrder(Order order, CancellationToken cancellationToken)
    {
        await dbContext.Order.AddAsync(order, cancellationToken);
    }

    public async Task AddOrderHistory(OrderStatusHistory orderStatusHistory,
                                             CancellationToken cancellationToken)
    {
        await dbContext.OrderStatusHistory.AddAsync(orderStatusHistory, cancellationToken);
    }

    public async Task AddOrderItems(OrderItems items, CancellationToken cancellationToken)
    {
        await dbContext.OrderItems.AddAsync(items, cancellationToken);
    }

    public async Task<OrderDto?> GetOrderById(Guid orderId, CancellationToken cancellationToken)
    {
        return await dbContext.Order.AsNoTracking()
                                    .Select(p => new OrderDto
                                    {
                                        Id = p.Id,
                                        Total = p.Total,
                                        CreatedAt = p.CreatedAt,
                                        Items = dbContext.OrderItems
                                                         .Include(x => x.Product)
                                                         .Where(x => x.OrderId == orderId)
                                                         .ToList(),
                                        StatusHistory = dbContext.OrderStatusHistory
                                                                 .Include(x => x.Status)
                                                                 .Where(x => x.OrderId == orderId)
                                                                 .ToList()
                                    })
                                    .FirstOrDefaultAsync(x => x.Id == orderId, cancellationToken);
    }

    public async Task<List<OrderStatusHistory>> GetOrderHistory(Guid orderId, CancellationToken cancellationToken)
    {
        return await dbContext.OrderStatusHistory.AsNoTracking()
                                                 .Where(x => x.OrderId == orderId)
                                                 .ToListAsync(cancellationToken);
    }

    public async Task<List<OrderItems>> GetOrderItems(Guid orderId, CancellationToken cancellationToken)
    {
        return await dbContext.OrderItems.AsNoTracking()
                                         .Where(x => x.Id == orderId)
                                         .ToListAsync(cancellationToken);
    }

    public async Task<List<OrderDto>> GetUserOrders(Guid userId, CancellationToken cancellationToken)
    { 
        return await dbContext.Order.AsNoTracking()
                                    .Where(x => x.UserId == userId)
                                    .Select(p => new OrderDto
                                    {
                                        Id = p.Id,
                                        Total = p.Total,
                                        CreatedAt = p.CreatedAt,
                                        Items = dbContext.OrderItems
                                                         .Include(x => x.Product)
                                                         .Where(x => x.OrderId == p.Id)
                                                         .ToList(),
                                        StatusHistory = dbContext.OrderStatusHistory
                                                                 .Include(x => x.Status)
                                                                 .Where(x => x.OrderId == p.Id)
                                                                 .ToList()
                                    })
                                    .ToListAsync(cancellationToken);
    }

    public async Task UpdateOrder(Guid orderId, CancellationToken cancellationToken)
    {
        await dbContext.Order.Where(x => x.Id == orderId)
                             .ExecuteUpdateAsync(p => p
                             .SetProperty(n => n.UpdatedAt, DateTimeOffset.UtcNow),
                             cancellationToken);
    }
}
