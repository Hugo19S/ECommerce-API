using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class CategoryRepository(ECommerceDbContext dbContext) : ICategoryRepository
{
    public async Task AddCategoty(Category category, CancellationToken cancellationToken)
    {
        await dbContext.Category.AddAsync(category, cancellationToken);
    }

    public async Task DeleteCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        await dbContext.Category.Where(x => x.Id == categoryId)
                                .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<Category>> GetAllCategories(CancellationToken cancellationToken)
    {
        return await dbContext.Category.ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetCategoryById(Guid categoryId, CancellationToken cancellationToken)
    {
        return await dbContext.Category.AsNoTracking().FirstOrDefaultAsync(x => x.Id == categoryId, cancellationToken);
    }

    public async Task<Category?> GetCategoryByName(string categoryName, CancellationToken cancellationToken)
    {
        return await dbContext.Category.AsNoTracking().FirstOrDefaultAsync(x => x.Name == categoryName, cancellationToken);
    }

    public async Task UpdateCategory(Guid categoryId, string name, string description, CancellationToken cancellationToken)
    {
        await dbContext.Category.Where(x => x.Id == categoryId)
                                .ExecuteUpdateAsync(p => p
                                .SetProperty(c => c.Name, name)
                                .SetProperty(c => c.Description, description)
                                .SetProperty(c => c.UpdatedAt, DateTimeOffset.UtcNow),
                                cancellationToken);
    }
}
