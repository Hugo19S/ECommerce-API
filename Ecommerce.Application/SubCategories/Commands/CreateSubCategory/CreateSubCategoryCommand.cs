using Ecommerce.Application.Common;
using Ecommerce.Application.CustomErrors;
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
            return DomainErrors.NotFound("Category", request.CategoryId);

        var sameName = await subCategoryRepository.GetSubCategoryByName(request.Name, cancellationToken);

        if (sameName != null)
            return DomainErrors.Conflict("SubCategory");

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
