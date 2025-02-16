using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Makers.Commands.CreateMaker;

public record CreateMakerCommand(string Name) : IRequest<ErrorOr<Created>>;

public class CreateMakerCommandHandler(IMakerRepostory repostory, IUnitOfWork unitOfWork)
    : IRequestHandler<CreateMakerCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateMakerCommand request, CancellationToken cancellationToken)
    {
        var makerExist = await repostory.GetMakerByName(request.Name, cancellationToken);

        if (makerExist != null) 
        {
            return Error.Conflict("Maker.Conflict", "There's already a maker with the same name!");
        }

        var newMaker = new Maker
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CreatedAt = DateTimeOffset.UtcNow,
        };

        await repostory.AddMaker(newMaker, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
