using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab12.Data;
using Lab12.Models;

namespace Lab12.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            Products = await _context.Products.OrderByDescending(p => p.CreatedAt).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(string Name, decimal Price, string Description)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = new Product
            {
                Name = Name,
                Price = Price,
                Description = Description,
                CreatedAt = DateTime.UtcNow
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
