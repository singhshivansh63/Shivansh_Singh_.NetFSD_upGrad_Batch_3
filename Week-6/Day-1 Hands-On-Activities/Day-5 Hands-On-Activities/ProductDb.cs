using ProductApp.Models;
using System.Collections.Generic;

namespace MvcCrudApp.Data
{
    public static class ProductDb
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product{ Id = 1, Name="Laptop", Price=55000, Category="Electronics"},
            new Product{ Id = 2, Name="Mobile", Price=20000, Category="Gadgets"}
        };
    }
}
