using ErrorOr;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

internal interface ICategoryRepository
{
    Task<ErrorOr<Created>> AddCategoty(string name,
                                       string? desciption,
                                       CancellationToken cancellationToken);
    Task<List<Category>> GetAllCategories(CancellationToken cancellationToken);
    Task<ErrorOr<Category>> GetCategoryById(Guid categoryId, CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateCategory(Guid categoryId, Guid name, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteCategory(Guid categoryId, CancellationToken cancellationToken);
}
