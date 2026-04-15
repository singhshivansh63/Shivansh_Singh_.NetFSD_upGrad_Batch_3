using Product_Service.Models;
 

namespace Product_Service.Services
{
    public class ProductService
    {
        // ✅ Hardcoded data
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "iPhone 15", Price = 79999, Stock = 10 },
            new Product { Id = 2, Name = "Samsung S24", Price = 69999, Stock = 5 },
            new Product { Id = 3, Name = "OnePlus 12", Price = 54999, Stock = 8 }
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product GetById(int id)
        {
            return products.FirstOrDefault(p => p.Id == id);
        }
    }
}