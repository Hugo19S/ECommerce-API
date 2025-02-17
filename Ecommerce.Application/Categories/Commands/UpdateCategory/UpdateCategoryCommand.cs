using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(Guid CategoryId, string Name, string? Description) : IRequest<ErrorOr<Updated>>;

public class UpdateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateCategoryCommand, ErrorOr<Updated>>

{
    public async Task<ErrorOr<Updated>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryWithSameName = await repository.GetCategoryByName(request.Name, cancellationToken);

        if (categoryWithSameName != null)
        {
            return Error.Conflict("Category.Conflict", "There's already a category with the same name!");
        }

        var categoryExist = await repository.GetCategoryById(request.CategoryId, cancellationToken);

        if (categoryExist == null)
        {
            return Error.NotFound("Category.NotFound", $"Category with id {request.CategoryId} not found.");
        }

        await repository.UpdateCategory(request.CategoryId, request.Name, request.Description, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
