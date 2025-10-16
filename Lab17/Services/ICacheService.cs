using System.Threading.Tasks;

namespace Lab17.Services
{
    public interface ICacheService
    {
        // Методы для работы с встроенным кэшем
        T GetOrSetMemoryCache<T>(string key, Func<T> getData, TimeSpan? expiration = null);
        
        // Методы для работы с распределенным кэшем
        Task<T> GetOrSetDistributedCacheAsync<T>(string key, Func<Task<T>> getData, TimeSpan? expiration = null);
        
        // Методы для работы с кэшем на диске
        T GetOrSetFileCache<T>(string key, Func<T> getData, TimeSpan? expiration = null);
        
        // Методы для очистки кэша
        void RemoveMemoryCache(string key);
        Task RemoveDistributedCacheAsync(string key);
        void RemoveFileCache(string key);
    }
} 