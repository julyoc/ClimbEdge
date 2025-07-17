using ClimbEdge.Common.Constants;
using ClimbEdge.Domain.Shared;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Caching
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public Task<T?> GetAsync<T>(string key) where T : BaseModel
        {
            _memoryCache.TryGetValue(key, out T? value);
            return Task.FromResult(value);
        }

        public Task SetAsync<T>(string key, T value, int expiration = Constants.CachingExpiration) where T : BaseModel
        {
            _memoryCache.Set(key, value, TimeSpan.FromSeconds(expiration));
            return Task.CompletedTask;
        }
    }
}
