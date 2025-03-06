using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Ecommerce.Application.Statuses.Commands.PatchStatus;

public record PatchStatusCommand(Guid StatusId, JsonPatchDocument<Status> JsonPatch) : IRequest<ErrorOr<Updated>>;

public class PatchStatusCommandHandler(IStatusRepository statusRepository, IUnitOfWork unitOfWork) : IRequestHandler<PatchStatusCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(PatchStatusCommand request, CancellationToken cancellationToken)
    {
        if (request.JsonPatch.Operations.Any(op => op.OperationType is OperationType.Move or OperationType.Copy))
            return DomainErrors.OperationUnauthorized();

        if (request.JsonPatch is null || request.JsonPatch.Operations.Count == 0)
            return DomainErrors.JSonPatchNotFound();

        var status = await statusRepository.GetStatusById(request.StatusId, cancellationToken);

        if (status == null)
            return DomainErrors.NotFound("Status", request.StatusId);

        var nameOperation = request.JsonPatch.Operations.FirstOrDefault(op =>
                (op.OperationType is OperationType.Add or OperationType.Replace) &&
                 op.path.Equals("/name", StringComparison.OrdinalIgnoreCase));


        if (nameOperation!.value is string nameValue)
        {
            var nameExist = await statusRepository.GetStatusByName(nameValue, status.Type, cancellationToken);

            if (nameExist != null)
                return DomainErrors.Conflict("Status");
        }

        request.JsonPatch.ApplyTo(status);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
