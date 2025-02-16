using Ecommerce.Application.Common;
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
        {
            return Error.NotFound("Maker.NotFound", $"Maker with id {request.MakerId} not found.");
        }
        
        var makerWithSameName = await repostory.GetMakerByName(request.Name, cancellationToken);

        if (makerWithSameName != null) 
        {
            return Error.Conflict("Maker.Conflict", "There's already a maker with the same name!");
        }

        await repostory.UpdateMaker(request.MakerId, request.Name, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
