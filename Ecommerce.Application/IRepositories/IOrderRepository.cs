using ErrorOr;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IOrderRepository
{
    Task<ErrorOr<Created>> AddOrder(Guid userId, float total, CancellationToken cancellationToken);
    Task<ErrorOr<Order>> GetOrderById(Guid orderId, CancellationToken cancellationToken);
    Task<List<Order>> GetAllOrder(Guid userId, CancellationToken cancellationToken);
    Task<List<Order>> GetOrderHistory(Guid orderId, CancellationToken cancellationToken);
    Task<List<Updated>> UpdateOrder(Guid orderId, Guid statusId, string? note, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteOrder(Guid orderId, CancellationToken cancellationToken);
}
