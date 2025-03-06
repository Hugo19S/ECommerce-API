using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Statuses.Commands.UpdateStatus;

public record UpdateStatusCommand(Guid StatusId, string Name, string Type, string? Description) : IRequest<ErrorOr<Updated>>;

public class UpdateStatusCommandHandler(IStatusRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateStatusCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
    {
        var statusExist = await repository.GetStatusById(request.StatusId, cancellationToken);

        if (statusExist == null)
            return DomainErrors.NotFound("Status", request.StatusId);

        await repository.UpdateStatus(request.StatusId ,request.Name ,request.Type ,request.Description, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
