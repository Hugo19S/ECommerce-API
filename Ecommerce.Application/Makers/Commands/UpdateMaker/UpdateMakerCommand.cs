using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Makers.Commands.UpdateMaker;

public record UpdateMakerCommand(Guid MakerId, string Name) : IRequest<ErrorOr<Updated>>;

public class UpdateMakerCommandHandler(IMakerRepostory repostory, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateMakerCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateMakerCommand request, CancellationToken cancellationToken)
    {
        var makerExist = await repostory.GetMakerById(request.MakerId, cancellationToken);

        if (makerExist == null) 
            return DomainErrors.NotFound("Maker", request.MakerId);
        
        var makerWithSameName = await repostory.GetMakerByName(request.Name, cancellationToken);

        if (makerWithSameName != null)
            return DomainErrors.Conflict("Maker");

        await repostory.UpdateMaker(request.MakerId, request.Name, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
