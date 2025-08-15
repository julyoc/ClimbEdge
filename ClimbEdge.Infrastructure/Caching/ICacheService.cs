using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Caching
{
    public interface ICacheService
    {
        /// <summary>
        /// Sets a value in the cache.
        /// </summary>
        /// <typeparam name="T">The type of the value to cache.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <param name="value">The value to cache.</param>
        /// <param name="expiration">The expiration time in seconds.</param>
        /// <returns></returns>
        Task SetAsync<T>(string key, T value, int expiration = Constants.CachingExpiration);
        /// <summary>
        /// Gets a value from the cache.
        /// </summary>
        /// <typeparam name="T">The type of the value to retrieve.</typeparam>
        /// <param name="key">The cache key.</param>
        /// <returns>The cached value or null if not found.</returns>
        Task<T?> GetAsync<T>(string key);
        /// <summary>
        /// Removes a value from the cache.
        /// </summary>
        /// <param name="key">The cache key.</param>
        /// <returns></returns>
        Task RemoveAsync(string key);
        /// <summary>
        /// Removes all values from the cache with the specified prefix.
        /// </summary>
        /// <param name="prefix">The cache key prefix.</param>
        /// <returns></returns>
        Task RemoveByPrefixAsync(string prefix);
    }
}
