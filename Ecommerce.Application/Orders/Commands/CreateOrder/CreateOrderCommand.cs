using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid UserId, float Value,
                                 List<OrderItemsRequest> OrderItems) : IRequest<ErrorOr<Created>>;

public class CreateOrderCommandHandler(IOrderRepository orderRepository,
                                       IUserRepository userRepository,
                                       IProductRepository productRepository,
                                       IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.UserId, cancellationToken);

        if (user == null)
            return DomainErrors.NotFound("User", request.UserId);

        var orderId = Guid.NewGuid();

        var order = new Order
        {
            Id = orderId,
            UserId = request.UserId,
            Total = request.Value,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await orderRepository.AddOrder(order, cancellationToken);

        foreach (var item in request.OrderItems)
        {
            var product = await productRepository.GetProductById(item.ProductId, cancellationToken);

            if (product == null) 
                return DomainErrors.NotFound("Product", item.ProductId);

            var orderItems = new OrderItems
            {
                Id = Guid.NewGuid(),
                OrderId = orderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };

            await orderRepository.AddOrderItems(orderItems, cancellationToken);
        }

        var orderHistory = new OrderStatusHistory
        {
            Id = Guid.NewGuid(),
            OrderId = orderId,
            StatusId = Guid.Parse("dee7068f-954b-4f4a-8d93-a9da05a478d4"),
            CreatedAt = DateTimeOffset.UtcNow
        };

        await orderRepository.AddOrderHistory(orderHistory, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
