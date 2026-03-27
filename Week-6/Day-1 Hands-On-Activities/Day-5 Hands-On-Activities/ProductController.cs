using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
         
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Description = "High performance laptop", Price = 75000, Category = "Electronics" },
            new Product { Id = 2, Name = "Smartphone", Description = "Android flagship phone", Price = 35000, Category = "Mobiles" },
            new Product { Id = 3, Name = "Headphones", Description = "Noise Cancelling", Price = 8000, Category = "Audio" }
        };

         
        public IActionResult Index()
        {
            return View(products);
        }

        
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

     
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                products.Add(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }

       
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
         
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = products.FirstOrDefault(p => p.Id == updatedProduct.Id);

                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;
                existingProduct.Category = updatedProduct.Category;

                return RedirectToAction("Index");
            }

            return View(updatedProduct);
        }

        
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}