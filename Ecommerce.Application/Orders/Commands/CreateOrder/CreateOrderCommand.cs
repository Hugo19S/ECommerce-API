using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Common;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid UserId,
                                 float Value,
                                 List<OrderItemsRequest> OrderItems) : IRequest<ErrorOr<Created>>;

public class CreateOrderCommandHandler(IOrderRepository orderRepository,
                                       IUserRepository userRepository,
                                       IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserById(request.UserId, cancellationToken);

        if (user == null)
        {
            return Error.NotFound("User.NotFound", $"User with id {request.UserId} not found.");
        }

        var order = new Order
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Total = request.Value,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await orderRepository.AddOrder(order, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
