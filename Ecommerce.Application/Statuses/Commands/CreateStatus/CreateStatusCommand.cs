using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Statuses.Commands.CreateStatus;

public record CreateStatusCommand(string Name, string Type, string? Description) : IRequest<ErrorOr<Created>>;

public class CreateStatusCommandHandler(IStatusRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateStatusCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        var statusWithSameName = await repository.GetStatusByName(request.Name, request.Type, cancellationToken);

        if (statusWithSameName != null)
        {
            return Error.Conflict("Status.Conflict", "There's already a statute of the same name on this type!");
        }

        var createStatus = new Status
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Type = request.Type,
            Description = request.Description
        };

        await repository.AddStatus(createStatus, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
