using ClimbEdge.Domain.Shared;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClimbEdge.Infrastructure.Caching
{
    public class CacheService(IDistributedCache cache) : ICacheService
    {
        private readonly IDistributedCache _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        private const string KeySetPrefix = "__cache_keyset__";

        public async Task<T?> GetAsync<T>(string key)
        {
            var json = await _cache.GetStringAsync(key);
            return json is null ? default : JsonSerializer.Deserialize<T>(json);
        }
        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
            // Remove key from index
            await RemoveKeyFromIndexAsync(key);
        }
        public async Task RemoveByPrefixAsync(string prefix)
        {
            // Get all keys that start with the prefix
            var keysToRemove = await GetKeysByPrefixAsync(prefix);
            
            // Remove all matching keys
            var removeTasks = keysToRemove.Select(async key =>
            {
                await _cache.RemoveAsync(key);
                await RemoveKeyFromIndexAsync(key);
            });
            
            await Task.WhenAll(removeTasks);
        }
        private async Task AddKeyToIndexAsync(string key, int expiration)
        {
            try
            {
                // Store the key in a set organized by prefix
                var prefixKey = GetPrefixKeyForIndex(key);
                var existingKeysJson = await _cache.GetStringAsync(prefixKey);
                var keySet = existingKeysJson != null 
                    ? JsonSerializer.Deserialize<HashSet<string>>(existingKeysJson) ?? new HashSet<string>()
                    : new HashSet<string>();
                
                keySet.Add(key);
                
                var updatedJson = JsonSerializer.Serialize(keySet);
                await _cache.SetStringAsync(prefixKey, updatedJson, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expiration + 300) // Give extra time for cleanup
                });
            }
            catch
            {
                // If index update fails, we continue - the cache will still work
                // but RemoveByPrefixAsync might not find all keys
            }
        }
        private async Task RemoveKeyFromIndexAsync(string key)
        {
            try
            {
                var prefixKey = GetPrefixKeyForIndex(key);
                var existingKeysJson = await _cache.GetStringAsync(prefixKey);
                if (existingKeysJson != null)
                {
                    var keySet = JsonSerializer.Deserialize<HashSet<string>>(existingKeysJson) ?? new HashSet<string>();
                    keySet.Remove(key);
                    
                    if (keySet.Count > 0)
                    {
                        var updatedJson = JsonSerializer.Serialize(keySet);
                        await _cache.SetStringAsync(prefixKey, updatedJson);
                    }
                    else
                    {
                        await _cache.RemoveAsync(prefixKey);
                    }
                }
            }
            catch
            {
                // If index update fails, we continue - the cache will still work
            }
        }
        private async Task<List<string>> GetKeysByPrefixAsync(string prefix)
        {
            var allKeys = new List<string>();
            
            try
            {
                // This is a simplified approach - in production you might want to
                // organize keys by common prefixes for better performance
                var indexKey = GetPrefixKeyForIndex(prefix);
                var keysJson = await _cache.GetStringAsync(indexKey);
                
                if (keysJson != null)
                {
                    var keySet = JsonSerializer.Deserialize<HashSet<string>>(keysJson) ?? new HashSet<string>();
                    allKeys.AddRange(keySet.Where(k => k.StartsWith(prefix)));
                }
                
                // Also check for partial matches in other prefix buckets
                // This is a basic implementation - for better performance in production,
                // you'd want a more sophisticated indexing strategy
                for (int i = 1; i <= prefix.Length; i++)
                {
                    var partialPrefix = prefix.Substring(0, i);
                    var partialIndexKey = GetPrefixKeyForIndex(partialPrefix);
                    var partialKeysJson = await _cache.GetStringAsync(partialIndexKey);
                    
                    if (partialKeysJson != null)
                    {
                        var partialKeySet = JsonSerializer.Deserialize<HashSet<string>>(partialKeysJson) ?? new HashSet<string>();
                        allKeys.AddRange(partialKeySet.Where(k => k.StartsWith(prefix) && !allKeys.Contains(k)));
                    }
                }
            }
            catch
            {
                // If we can't read the index, return empty list
            }
            
            return allKeys.Distinct().ToList();
        }
        private string GetPrefixKeyForIndex(string key)
        {
            // Create an index key based on the first few characters to organize keys
            var prefix = key.Length >= 3 ? key.Substring(0, 3) : key;
            return $"{KeySetPrefix}_{prefix}";
        }
        public async Task SetAsync<T>(string key, T value, int expiration)
        {
            var json = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, json, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(expiration)
            });
            
            // Add key to index for prefix removal support
            await AddKeyToIndexAsync(key, expiration);
        }
    }
}
