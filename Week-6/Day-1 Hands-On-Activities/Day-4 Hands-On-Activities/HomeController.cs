using Microsoft.AspNetCore.Mvc;

namespace MyFirstMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "My First MVC App";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
