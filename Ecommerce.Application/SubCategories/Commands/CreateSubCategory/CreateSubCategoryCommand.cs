using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.SubCategories.Commands.CreateSubCategory;

public record CreateSubCategoryCommand(string Name, string Description, Guid CategoryId): IRequest<ErrorOr<Created>>;

public class CreateSubCategoryCommandHandler(ISubCategoryRepository subCategoryRepository,
                                             ICategoryRepository categoryRepository,
                                             IUnitOfWork unitOfWork)
    : IRequestHandler<CreateSubCategoryCommand, ErrorOr<Created>>
{
    public async Task<ErrorOr<Created>> Handle(CreateSubCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetCategoryById(request.CategoryId, cancellationToken);

        if (category == null)
        {
            return Error.NotFound("Category.NotFound", $"Category with id {request.CategoryId} not found.");
        }

        var sameName = await subCategoryRepository.GetSubCategoryByName(request.Name, cancellationToken);

        if (sameName != null)
        {
            return Error.Conflict("SubCategory.Conflict", "There's already a subCategory with the same name!");
        }

        var subcategory = new SubCategory
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            CategoryId = request.CategoryId,
            CreatedAt = DateTimeOffset.UtcNow
        };

        await subCategoryRepository.AddSubCategory(subcategory, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new Created();
    }
}
