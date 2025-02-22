using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.SubCategories.Commands.UpdateSubCategory;

public record UpdateSubCategoryCommand(Guid SubCategoryId, string Name, string Description)
    : IRequest<ErrorOr<Updated>>;

public class UpdateSubCategoryCommandHandler(ISubCategoryRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateSubCategoryCommand, ErrorOr<Updated>>
{
    public async Task<ErrorOr<Updated>> Handle(UpdateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var subCategory = await repository.GetSubCategoryById(request.SubCategoryId, cancellationToken);

        if (subCategory == null)
        {
            return Error.NotFound("SubCategory.NotFound", $"SubCategory with id {request.SubCategoryId} not found.");
        }

        var sameName = await repository.GetSubCategoryByName(request.Name, cancellationToken);

        if (sameName != null)
        {
            return Error.Conflict("SubCategory.Conflict", "There's already a subCategory with the same name!");
        }

        await repository.UpdateSubCategory(request.SubCategoryId, request.Name,
                                           request.Description, cancellationToken);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Updated();
    }
}
