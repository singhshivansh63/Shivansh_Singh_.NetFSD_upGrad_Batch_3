using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReportProcessingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Report Processing Started ===\n");

            
            Task salesTask = Task.Run(() => GenerateSalesReport());
            Task inventoryTask = Task.Run(() => GenerateInventoryReport());
            Task customerTask = Task.Run(() => GenerateCustomerReport());

             
            Task.WaitAll(salesTask, inventoryTask, customerTask);

            Console.WriteLine("\n=== All Reports Generated Successfully ===");
            Console.ReadLine();
        }

         
        static void GenerateSalesReport()
        {
            Console.WriteLine("Sales Report Generation Started...");
            Thread.Sleep(3000);  
            Console.WriteLine("Sales Report Generation Completed!");
        }

         
        static void GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report Generation Started...");
            Thread.Sleep(4000);  
            Console.WriteLine("Inventory Report Generation Completed!");
        }

        
        static void GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report Generation Started...");
            Thread.Sleep(2000);  
            Console.WriteLine("Customer Report Generation Completed!");
        }
    }
}
