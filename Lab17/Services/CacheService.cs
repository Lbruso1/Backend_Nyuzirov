using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;

namespace Lab17.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;
        private readonly string _fileCachePath;

        public CacheService(
            IMemoryCache memoryCache,
            IDistributedCache distributedCache)
        {
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
            _fileCachePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cache");
            
            if (!Directory.Exists(_fileCachePath))
            {
                Directory.CreateDirectory(_fileCachePath);
            }
        }

        public T GetOrSetMemoryCache<T>(string key, Func<T> getData, TimeSpan? expiration = null)
        {
            if (_memoryCache.TryGetValue(key, out T? cachedValue))
            {
                return cachedValue!;
            }

            var value = getData();
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(expiration ?? TimeSpan.FromMinutes(5));

            _memoryCache.Set(key, value, cacheEntryOptions);
            return value;
        }

        public async Task<T> GetOrSetDistributedCacheAsync<T>(string key, Func<Task<T>> getData, TimeSpan? expiration = null)
        {
            var cachedValue = await _distributedCache.GetStringAsync(key);
            if (cachedValue != null)
            {
                return JsonSerializer.Deserialize<T>(cachedValue)!;
            }

            var value = await getData();
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(expiration ?? TimeSpan.FromMinutes(5));

            await _distributedCache.SetStringAsync(
                key,
                JsonSerializer.Serialize(value),
                options);

            return value;
        }

        public T GetOrSetFileCache<T>(string key, Func<T> getData, TimeSpan? expiration = null)
        {
            var filePath = Path.Combine(_fileCachePath, $"{key}.cache");
            
            if (File.Exists(filePath))
            {
                var fileContent = File.ReadAllText(filePath);
                var existingCacheInfo = JsonSerializer.Deserialize<CacheInfo<T>>(fileContent);
                if (existingCacheInfo?.ExpirationTime > DateTime.UtcNow)
                {
                    return existingCacheInfo.Data!;
                }
            }

            var value = getData();
            var newCacheInfo = new CacheInfo<T>
            {
                Data = value,
                ExpirationTime = DateTime.UtcNow.Add(expiration ?? TimeSpan.FromMinutes(5))
            };

            File.WriteAllText(filePath, JsonSerializer.Serialize(newCacheInfo));
            return value;
        }

        public void RemoveMemoryCache(string key)
        {
            _memoryCache.Remove(key);
        }

        public async Task RemoveDistributedCacheAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public void RemoveFileCache(string key)
        {
            var filePath = Path.Combine(_fileCachePath, $"{key}.cache");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }

    public class CacheInfo<T>
    {
        public required T Data { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
} 