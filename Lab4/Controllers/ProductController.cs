using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult List(string category, int? id)
        {
            ViewBag.Category = category;
            ViewBag.Id = id;
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewBag.ProductId = id;
            return View();
        }
    }
} 