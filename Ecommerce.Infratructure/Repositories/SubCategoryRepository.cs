using Ecommerce.Application.IRepositories;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infratructure.Repositories;

public class SubCategoryRepository(ECommerceDbContext dbContext) : ISubCategoryRepository
{
    public async Task AddSubCategory(SubCategory subCategory, CancellationToken cancellationToken)
    {
        await dbContext.SubCategory.AddAsync(subCategory, cancellationToken);
    }

    public async Task DeleteSubCategory(Guid subCategoryId, CancellationToken cancellationToken)
    {
        await dbContext.SubCategory.Where(x => x.Id == subCategoryId)
                                   .ExecuteDeleteAsync(cancellationToken);
    }

    public async Task<List<SubCategory>> GetSubCategoriesByCategory(Guid categoryId, CancellationToken cancellationToken)
    {
        return await dbContext.SubCategory.Where(x => x.CategoryId == categoryId)
                                          .ToListAsync(cancellationToken);
    }

    public async Task<SubCategory?> GetSubCategoryById(Guid subCategoryId, CancellationToken cancellationToken)
    {
        return await dbContext.SubCategory.FirstOrDefaultAsync(x => x.Id == subCategoryId, cancellationToken);
    }

    public Task<SubCategory?> GetSubCategoryByName(string name, CancellationToken cancellationToken)
    {
        return dbContext.SubCategory.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
    }

    public async Task UpdateSubCategory(Guid subCategoryId,
                                  string name,
                                  string? description,
                                  CancellationToken cancellationToken)
    {
        await dbContext.SubCategory.Where(x => x.Id == subCategoryId)
                                   .ExecuteUpdateAsync(p => p
                                   .SetProperty(n => n.Name, name)
                                   .SetProperty(n => n.Description, description),
                                   cancellationToken);
    }
}
