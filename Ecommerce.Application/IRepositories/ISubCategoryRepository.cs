using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

public interface ISubCategoryRepository
{
    Task AddSubCategory(SubCategory subCategory, CancellationToken cancellationToken);
    Task<SubCategory?> GetSubCategoryById(Guid subCategoryId, CancellationToken cancellationToken);
    Task<SubCategory?> GetSubCategoryByName(string name, CancellationToken cancellationToken);
    Task<List<SubCategory>> GetSubCategoriesByCategory(Guid categoryId, CancellationToken cancellationToken);
    Task UpdateSubCategory(Guid subCategoryId, string name, string? description, CancellationToken cancellationToken);
    Task DeleteSubCategory(Guid subCategoryId, CancellationToken cancellationToken);
}
