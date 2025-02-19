using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.IRepositories;

public interface ISellerRepository
{
    Task AddSeller(Seller seller, CancellationToken cancellationToken);
    Task<Seller?> GetSellerById(Guid sellerId, CancellationToken cancellationToken);
    Task<Seller?> GetSellerByName(string name, CancellationToken cancellationToken);
    Task<List<Seller>> GetAllSeller(CancellationToken cancellationToken);
    Task UpdateSeller(Guid sellerId, string name, CancellationToken cancellationToken);
    Task DeleteSeller(Guid sellerId, CancellationToken cancellationToken);
}
