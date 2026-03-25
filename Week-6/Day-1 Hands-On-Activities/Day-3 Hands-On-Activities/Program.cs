using ConsoleApp6.NewFolder1;
using ConsoleApp6.NewFolder;
using ConsoleApp6.NewFolder;
using ConsoleApp6.NewFolder1;
using System;
using System.Data;

class Program
{
    static void Main()
    {
        ProductRepository repo = new ProductRepository();

        while (true)
        {
            Console.WriteLine("\n==== PRODUCT MANAGEMENT SYSTEM ====");
            Console.WriteLine("1. Insert Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Update Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Insert(repo);
                    break;

                case "2":
                    View(repo);
                    break;

                case "3":
                    Update(repo);
                    break;

                case "4":
                    Delete(repo);
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    // ============== INSERT ============================
    static void Insert(ProductRepository repo)
    {
        Product p = new Product();

        Console.Write("Enter Product Name: ");
        p.ProductName = Console.ReadLine();

        Console.Write("Enter Category: ");
        p.Category = Console.ReadLine();

        Console.Write("Enter Price: ");
        p.Price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter Stock: ");
        p.Stock = int.Parse(Console.ReadLine());

        repo.InsertProduct(p);

        Console.WriteLine("Product inserted successfully!");
    }

    // ============== VIEW ============================
    static void View(ProductRepository repo)
    {
        DataTable dt = repo.GetAllProducts();

        Console.WriteLine("\n--- Product List ---");

        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine($"{row["ProductId"]} | {row["ProductName"]} | {row["Category"]} | {row["Price"]} | {row["Stock"]}");
        }
    }

    // ============== UPDATE ============================
    static void Update(ProductRepository repo)
    {
        Product p = new Product();

        Console.Write("Enter Product ID to Update: ");
        p.ProductId = int.Parse(Console.ReadLine());

        Console.Write("Enter New Name: ");
        p.ProductName = Console.ReadLine();

        Console.Write("Enter New Category: ");
        p.Category = Console.ReadLine();

        Console.Write("Enter New Price: ");
        p.Price = decimal.Parse(Console.ReadLine());

        Console.Write("Enter New Stock: ");
        p.Stock = int.Parse(Console.ReadLine());

        repo.UpdateProduct(p);

        Console.WriteLine("Product updated successfully!");
    }

    // ============== DELETE ============================
    static void Delete(ProductRepository repo)
    {
        Console.Write("Enter Product ID to Delete: ");
        int id = int.Parse(Console.ReadLine());

        repo.DeleteProduct(id);

        Console.WriteLine("Product deleted successfully!");
    }
}