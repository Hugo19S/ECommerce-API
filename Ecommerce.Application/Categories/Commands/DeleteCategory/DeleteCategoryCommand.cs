using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.Categories.Commands.DeleteCategory;

public record DeleteCategoryCommand(Guid CategoryId) : IRequest<ErrorOr<Deleted>>;

public class DeleteCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCategoryCommand, ErrorOr<Deleted>>
{
    public async Task<ErrorOr<Deleted>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryExist = await repository.GetCategoryById(request.CategoryId, cancellationToken);

        if (categoryExist == null)
        {
            return Error.NotFound("Category.NotFound", $"category with id {request.CategoryId} not found.");
        }

        await repository.DeleteCategory(request.CategoryId, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Deleted();
    }
}
