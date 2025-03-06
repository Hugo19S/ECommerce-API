using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Makers.Commands.DeleteMaker;

public record DeleteMakerCommand(Guid MakerId) : IRequest<ErrorOr<Deleted>>;

public class DeleteMakerCommandHandler(IMakerRepostory repostory, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteMakerCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteMakerCommand request, CancellationToken cancellationToken)
    {
        var makerExist = await repostory.GetMakerById(request.MakerId, cancellationToken);

        if (makerExist == null) 
            return DomainErrors.NotFound("Maker", request.MakerId);

        await repostory.DeleteMaker(request.MakerId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Deleted();
    }
}
