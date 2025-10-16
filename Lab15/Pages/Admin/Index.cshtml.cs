using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab15.Pages.Admin
{
    [Authorize(Policy = "RequireAdminRole")]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
} 