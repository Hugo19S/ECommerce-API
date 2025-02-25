using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Orders.Commands.UpdateOrderCommand;

public record UpdateOrderCommand(Guid OrderId, float Value) : IRequest<ErrorOr<Updated>>;

public class UpdateOrderCommandHandler(IOrderRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateOrderCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await repository.GetOrderById(request.OrderId, cancellationToken);

        if (order == null)
        {
            return Error.NotFound("Order.NotFound", $"Order with id {request.OrderId} not found.");
        }

        await repository.UpdateOrder(request.OrderId, request.Value, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
