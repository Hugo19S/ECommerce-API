using Ecommerce.Application.IRepositories;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Ecommerce.Infratructure.Repositories;


public class CacheRepository( IDistributedCache cache) : ICacheRepository
{
    private static readonly DistributedCacheEntryOptions Default = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(4)
    };

    public async Task DeleteCacheValue<T>(string cacheKey, CancellationToken cancellationToken)
    {
        await cache.RemoveAsync(cacheKey, cancellationToken);
    }

    public async Task<T?> GetCacheValueAsync<T>(string cacheKey, CancellationToken cancellationToken)
        where T : class
    {
        var cacheValue = await cache.GetStringAsync(cacheKey, cancellationToken);

        if (!string.IsNullOrWhiteSpace(cacheValue)) 
        {
            var value =  JsonSerializer.Deserialize<T>(cacheValue);

            if (value != null)
            {
                return value;
            }
            return null;
        }
        return null;
    }

    public async Task SetCacheValue<T>(string cacheKey, T value, CancellationToken cancellationToken)
    {
        await cache.SetStringAsync(cacheKey, JsonSerializer.Serialize(value), Default, cancellationToken);
    }
}
