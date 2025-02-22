using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.SubCategories.Commands.DeleteSubCategory;

public record DeleteSubCategoryCommand(Guid SubCategoryId) : IRequest<ErrorOr<Deleted>>;

public class DeleteSubCategoryCommandHandler(ISubCategoryRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteSubCategoryCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var subCategory = await repository.GetSubCategoryById(request.SubCategoryId, cancellationToken);

        if (subCategory == null)
        {
            return Error.NotFound("SubCategory.NotFound", $"SubCategory with id {request.SubCategoryId} not found.");
        }

        await repository.DeleteSubCategory(request.SubCategoryId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Deleted();
    }
}
