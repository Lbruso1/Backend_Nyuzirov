using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab8.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public string? SessionValue { get; set; }
    public string? CookieValue { get; set; }

    public void OnGet()
    {
        // Получаем значения из сессии и cookie при загрузке страницы
        SessionValue = HttpContext.Session.GetString("DemoValue");
        CookieValue = Request.Cookies["DemoValue"];
    }

    public IActionResult OnPostSession(string value)
    {
        // Сохраняем значение в сессию
        HttpContext.Session.SetString("DemoValue", value);
        return RedirectToPage();
    }

    public IActionResult OnPostCookie(string value)
    {
        // Сохраняем значение в cookie
        Response.Cookies.Append("DemoValue", value, new CookieOptions
        {
            Expires = DateTime.Now.AddDays(7),
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.Strict
        });
        return RedirectToPage();
    }
}
