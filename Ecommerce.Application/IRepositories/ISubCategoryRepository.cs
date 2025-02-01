using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

public interface ISubCategoryRepository
{
    Task<ErrorOr<Created>> AddSubCategory(string name, string? description, CancellationToken cancellationToken);
    Task<ErrorOr<SubCategory>> GetSubCategoryById(Guid subCategoryId, CancellationToken cancellationToken);
    Task<List<SubCategory>> GetAllSubCategoryOfCategory(Guid categoryId, CancellationToken cancellationToken);
    Task<List<SubCategory>> GetAllSubCategory(CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateSubCategory(Guid subCategoryId, string name, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteSubCategory(Guid subCategoryId, CancellationToken cancellationToken);
}
