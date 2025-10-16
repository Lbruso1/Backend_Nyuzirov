using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab17.Services;
using System.Diagnostics;

namespace Lab17.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICacheService _cacheService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ICacheService cacheService, ILogger<IndexModel> logger)
        {
            _cacheService = cacheService;
            _logger = logger;
        }

        public required string MemoryCacheResult { get; set; }
        public required string DistributedCacheResult { get; set; }
        public required string FileCacheResult { get; set; }
        public long MemoryCacheTime { get; set; }
        public long DistributedCacheTime { get; set; }
        public long FileCacheTime { get; set; }

        public async Task OnGetAsync()
        {
            // Тест встроенного кэша
            var memoryStopwatch = Stopwatch.StartNew();
            MemoryCacheResult = _cacheService.GetOrSetMemoryCache("memory_test", () =>
            {
                Thread.Sleep(1000); // Имитация долгой операции
                return $"Memory Cache Data: {DateTime.Now}";
            });
            memoryStopwatch.Stop();
            MemoryCacheTime = memoryStopwatch.ElapsedMilliseconds;

            // Тест распределенного кэша
            var distributedStopwatch = Stopwatch.StartNew();
            DistributedCacheResult = await _cacheService.GetOrSetDistributedCacheAsync("distributed_test", async () =>
            {
                await Task.Delay(1000); // Имитация долгой операции
                return $"Distributed Cache Data: {DateTime.Now}";
            });
            distributedStopwatch.Stop();
            DistributedCacheTime = distributedStopwatch.ElapsedMilliseconds;

            // Тест кэша на диске
            var fileStopwatch = Stopwatch.StartNew();
            FileCacheResult = _cacheService.GetOrSetFileCache("file_test", () =>
            {
                Thread.Sleep(1000); // Имитация долгой операции
                return $"File Cache Data: {DateTime.Now}";
            });
            fileStopwatch.Stop();
            FileCacheTime = fileStopwatch.ElapsedMilliseconds;
        }

        public async Task<IActionResult> OnPostClearCacheAsync()
        {
            _cacheService.RemoveMemoryCache("memory_test");
            await _cacheService.RemoveDistributedCacheAsync("distributed_test");
            _cacheService.RemoveFileCache("file_test");

            return RedirectToPage();
        }
    }
}
