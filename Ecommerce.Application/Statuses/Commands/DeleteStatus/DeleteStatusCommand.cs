using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Statuses.Commands.DeleteStatus
{
    public record DeleteStatusCommand(Guid StatusId) : IRequest<ErrorOr<Deleted>>;

    public class DeleteStatusCommandHandler(IStatusRepository statusRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteStatusCommand, ErrorOr<Deleted>>
    {
        public async Task<ErrorOr<Deleted>> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
        {
            var statusExist = await statusRepository.GetStatusById(request.StatusId, cancellationToken);

            if (statusExist == null) 
            {
                return Error.NotFound("Status.NotFound", $"Status with Id {request.StatusId} not found!");
            }

            await statusRepository.DeleteStatus(request.StatusId, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return new Deleted();
        }
    }
}
