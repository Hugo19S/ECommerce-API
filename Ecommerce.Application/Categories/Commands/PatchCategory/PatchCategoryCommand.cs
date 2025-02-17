using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Ecommerce.Application.Categories.Commands.PatchCategory;

public record PatchCategoryCommand(Guid CategoryId, JsonPatchDocument<Category> JsonPatch) : IRequest<ErrorOr<Updated>>;

public class PatchCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<PatchCategoryCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(PatchCategoryCommand request, CancellationToken cancellationToken)
    {
        if (request.JsonPatch.Operations.Any(op => op.OperationType is OperationType.Move or OperationType.Copy))
        {
            return Error.Unauthorized("Operation.Unauthorized", $"Moving and copying operations are not allowed!");
        }
        
        if (request.JsonPatch.Operations.Any(op => op.path.Equals("/createdat", StringComparison.OrdinalIgnoreCase) ||
                                                   op.path.Equals("/updatedat", StringComparison.OrdinalIgnoreCase)))
        {
            return Error.Unauthorized("Operation.Unauthorized", $"This operation is not allowed in this path!");
        }

        if (request.JsonPatch is null || request.JsonPatch.Operations.Count == 0)
        {
            return Error.NotFound("JSonPatch.NotFound", $"JSonPatch should not be empty!");
        }

        var category = await repository.GetCategoryById(request.CategoryId, cancellationToken);

        if (category == null)
        {
            return Error.NotFound("Category.NotFound", $"Category with Id {request.CategoryId} not found!");
        }

        var nameOperation = request.JsonPatch.Operations.FirstOrDefault(op =>
                (op.OperationType is OperationType.Add or OperationType.Replace) &&
                 op.path.Equals("/name", StringComparison.OrdinalIgnoreCase));


        if (nameOperation!.value is string nameValue)
        {
            var nameExist = await repository.GetCategoryByName(nameValue, cancellationToken);

            if (nameExist != null)
            {
                return Error.Conflict("Name.Conflict", "There's already a category of the same name on this type!");
            }
        }

        request.JsonPatch.ApplyTo(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
