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
        Task SetAsync<T>(string key, T value, int expiration = Constants.CachingExpiration);
        Task<T?> GetAsync<T>(string key);
        Task RemoveAsync(string key);
        Task RemoveByPrefixAsync(string prefix);
    }
}
