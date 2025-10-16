using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace Lab13.Pages;

public class LoginModel : PageModel
{
    [BindProperty]
    public string? Username { get; set; }
    [BindProperty]
    public string? Password { get; set; }
    public string? ErrorMessage { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            ErrorMessage = "Введите имя пользователя и пароль.";
            return Page();
        }

        // Примитивная проверка пользователя и ролей
        string? role = null;
        if (Username == "admin" && Password == "admin")
            role = "Admin";
        else if (Username == "user" && Password == "user")
            role = "User";

        if (role == null)
        {
            ErrorMessage = "Неверные имя пользователя или пароль.";
            return Page();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, Username!),
            new Claim(ClaimTypes.Role, role)
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true
        };
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity), authProperties);
        return RedirectToPage("/Index");
    }
} 