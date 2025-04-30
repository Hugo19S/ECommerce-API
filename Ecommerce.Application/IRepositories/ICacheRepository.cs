namespace Ecommerce.Application.IRepositories;

public interface ICacheRepository
{
    Task<T?> GetCacheValueAsync<T>(string cacheKey, CancellationToken cancellationToken)
        where T : class;

    Task SetCacheValue<T>(string cacheKey, T value, CancellationToken cancellationToken);
    Task DeleteCacheValue<T>(string cacheKey, CancellationToken cancellationToken);
}
