using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface ICategoryRepository
{
    Task AddCategoty(Domain.Entities.Category category, CancellationToken cancellationToken);
    Task<List<Domain.Entities.Category>> GetAllCategories(CancellationToken cancellationToken);
    Task<Domain.Entities.Category?> GetCategoryById(Guid categoryId, CancellationToken cancellationToken);
    Task<Domain.Entities.Category?> GetCategoryByName(string categoryName, CancellationToken cancellationToken);
    Task UpdateCategory(Guid categoryId, string name, string description, CancellationToken cancellationToken);
    Task DeleteCategory(Guid categoryId, CancellationToken cancellationToken);
}
