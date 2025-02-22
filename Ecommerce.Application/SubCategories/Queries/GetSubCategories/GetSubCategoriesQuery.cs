using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MediatR;

namespace Ecommerce.Application.SubCategories.Queries.GetSubCategories;

public record GetSubCategoriesQuery(Guid CategoryId) : IRequest<ErrorOr<List<SubCategory>>>;

public class GetSubCategoriesQueryHandler(ISubCategoryRepository subCategoryRepository,
                                          ICategoryRepository categoryRepository)
    : IRequestHandler<GetSubCategoriesQuery, ErrorOr<List<SubCategory>>>
{
    public async Task<ErrorOr<List<SubCategory>>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var category = await categoryRepository.GetCategoryById(request.CategoryId, cancellationToken);

        if (category == null)
        {
            return Error.NotFound("Category.NotFound", $"Category with id {request.CategoryId} not found.");
        }

        return await subCategoryRepository.GetSubCategoriesByCategory(request.CategoryId, cancellationToken);
    }
}
