using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 75000 },
            new Product { Id = 2, Name = "Smartphone", Description = "Android flagship phone", Price = 35000 },
            new Product { Id = 3, Name = "Headphones", Description = "Noise cancelling headphones", Price = 8000 }
        };

        // Index → Show all products
        public IActionResult Index()
        {
            return View(products);
        }

        // Details → Show one product
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}