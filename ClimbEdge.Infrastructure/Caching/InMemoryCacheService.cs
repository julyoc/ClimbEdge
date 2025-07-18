using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Shared;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Caching
{
    public class InMemoryCacheService(IMemoryCache memoryCache) : ICacheService
    {
        private readonly IMemoryCache _memoryCache = memoryCache;
        private readonly ConcurrentDictionary<string, byte> _keys = new ConcurrentDictionary<string, byte>();
        public Task<T?> GetAsync<T>(string key)
        {
            _memoryCache.TryGetValue(key, out T? value);
            return Task.FromResult(value);
        }

        public Task RemoveAsync(string key)
        {
            _memoryCache.Remove(key);
            _keys.TryRemove(key, out _); // Remove key from our index
            return Task.CompletedTask;
        }

        public Task RemoveByPrefixAsync(string prefix)
        {
            // Find all keys that start with the given prefix
            var keysToRemove = _keys.Keys.Where(key => key.StartsWith(prefix)).ToList();
            
            // Remove each key from both the cache and our index
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
                _keys.TryRemove(key, out _);
            }
            
            return Task.CompletedTask;
        }

        public Task SetAsync<T>(string key, T value, int expiration = Constants.CachingExpiration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromSeconds(expiration));
            _keys.TryAdd(key, 0); // Add key to our index
            return Task.CompletedTask;
        }
    }
}
