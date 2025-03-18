using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(Guid CategoryId, string Name, string? Description)
    : IRequest<ErrorOr<Updated>>;

public class UpdateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCategoryCommand, ErrorOr<Updated>>

{
    public async Task<ErrorOr<Updated>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryWithSameName = await repository.GetCategoryByName(request.Name, cancellationToken);

        if (categoryWithSameName != null)
            return DomainErrors.Conflict("Category");

        var categoryExist = await repository.GetCategoryById(request.CategoryId, cancellationToken);

        if (categoryExist == null)
            return DomainErrors.NotFound("Category", request.CategoryId);

        await repository.UpdateCategory(request.CategoryId, request.Name, request.Description, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
