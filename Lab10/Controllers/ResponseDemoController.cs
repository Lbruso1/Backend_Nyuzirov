using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Lab10.Controllers
{
    public class ResponseDemoController : Controller
    {
        // Возвращает HTML страницу
        public IActionResult GetHtmlPage()
        {
            return View();
        }

        // Возвращает JSON данные
        public IActionResult GetJsonData()
        {
            var data = new
            {
                Name = "Тестовые данные",
                Value = 42,
                Items = new[] { "Элемент 1", "Элемент 2", "Элемент 3" }
            };
            return Json(data);
        }

        // Возвращает текстовый файл
        public IActionResult GetTextFile()
        {
            var content = "Это содержимое текстового файла.\nСоздано для демонстрации.";
            var bytes = Encoding.UTF8.GetBytes(content);
            return File(bytes, "text/plain", "example.txt");
        }

        // Возвращает текстовый файл
        public IActionResult GetXmlData()
        {
            var content = "Это содержимое текстового файла.\n" +
                         "Создано для демонстрации.\n" +
                         "Строка 1\n" +
                         "Строка 2\n" +
                         "Строка 3";
            var bytes = Encoding.UTF8.GetBytes(content);
            return File(bytes, "text/plain", "demo.txt");
        }

        // Возвращает статус код
        public IActionResult GetStatusCode()
        {
            return StatusCode(200, "Привет, мир!");
        }
    }
} 