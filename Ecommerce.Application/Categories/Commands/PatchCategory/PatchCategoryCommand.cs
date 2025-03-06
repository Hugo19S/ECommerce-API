using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
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
            return DomainErrors.OperationUnauthorized();
        
        if (request.JsonPatch.Operations.Any(op => op.path.Equals("/createdat", StringComparison.OrdinalIgnoreCase) ||
                                                   op.path.Equals("/updatedat", StringComparison.OrdinalIgnoreCase)))
            return DomainErrors.OperationPathUnauthorized();

        if (request.JsonPatch is null || request.JsonPatch.Operations.Count == 0)
            return DomainErrors.JSonPatchNotFound();

        var category = await repository.GetCategoryById(request.CategoryId, cancellationToken);

        if (category == null)
            return DomainErrors.NotFound("Category", request.CategoryId);

        var nameOperation = request.JsonPatch.Operations.FirstOrDefault(op =>
                (op.OperationType is OperationType.Add or OperationType.Replace) &&
                 op.path.Equals("/name", StringComparison.OrdinalIgnoreCase));


        if (nameOperation!.value is string nameValue)
        {
            var nameExist = await repository.GetCategoryByName(nameValue, cancellationToken);

            if (nameExist != null)
                return DomainErrors.CategoryTypeConflict();
        }

        request.JsonPatch.ApplyTo(category);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
