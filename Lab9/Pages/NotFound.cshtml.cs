using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab9.Pages
{
    public class NotFoundModel : PageModel
    {
        private readonly ILogger<NotFoundModel> _logger;

        public NotFoundModel(ILogger<NotFoundModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogWarning("Пользователь попытался получить доступ к несуществующей странице: {Path}", HttpContext.Request.Path);
        }
    }
} 