using ErrorOr;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface IOrderItemsRepository
{
    Task<ErrorOr<Created>> AddOrdensItems(Guid orderId, Guid productId, int quantity,
                                          CancellationToken cancellationToken);
    Task<ErrorOr<OrderItems>> GetOrderItemsById(Guid OrderItemsId, CancellationToken cancellationToken);
    Task<List<OrderItems>> GetAllOrderItems(Guid orderId, CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateOrdensItems(Guid orderItemsId, int quantity, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteOrdensItems(Guid orderItemsId, CancellationToken cancellationToken);
}
