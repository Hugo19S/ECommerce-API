using Ecommerce.Domain.Entities;
using ErrorOr;

namespace Ecommerce.Application.IRepositories;

public interface ISellerRepository
{
    Task<ErrorOr<Created>> AddSeller(string name, CancellationToken cancellationToken);
    Task<ErrorOr<Seller>> GetSellerById(Guid sellerId, CancellationToken cancellationToken);
    Task<List<Seller>> GetAllSeller(CancellationToken cancellationToken);
    Task<ErrorOr<Updated>> UpdateSeller(Guid sellerId, string name, CancellationToken cancellationToken);
    Task<ErrorOr<Deleted>> DeleteSeller(Guid sellerId, CancellationToken cancellationToken);
}
