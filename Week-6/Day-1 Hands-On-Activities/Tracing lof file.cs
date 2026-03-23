using System;
using System.Diagnostics;
using System.IO;

namespace OrderProcessingTracing
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string logFilePath = "OrderTraceLog.txt";

            Trace.Listeners.Clear();  
            Trace.Listeners.Add(new TextWriterTraceListener(logFilePath));
            Trace.AutoFlush = true;

            Trace.TraceInformation("=== Order Processing Application Started ===");

            try
            {
                ProcessOrder(101);
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex.Message);
            }

            Trace.TraceInformation("=== Application Finished ===");

            Console.WriteLine("Order processing completed. Check log file for details.");
            Console.ReadLine();
        }

        static void ProcessOrder(int orderId)
        {
            Trace.WriteLine($"Processing Order ID: {orderId}");

            ValidateOrder(orderId);
            ProcessPayment(orderId);
            UpdateInventory(orderId);
            GenerateInvoice(orderId);

            Trace.WriteLine($"Order ID {orderId} processed successfully.\n");
        }

        static void ValidateOrder(int orderId)
        {
            Trace.TraceInformation("Step 1: Validating Order...");

            
            if (orderId <= 0)
            {
                throw new Exception("Invalid Order ID");
            }

            Trace.WriteLine("Order validation successful.");
        }

        static void ProcessPayment(int orderId)
        {
            Trace.TraceInformation("Step 2: Processing Payment...");

             
            bool paymentSuccess = true;  

            if (!paymentSuccess)
            {
                throw new Exception("Payment Failed!");
            }

            Trace.WriteLine("Payment processed successfully.");
        }

        static void UpdateInventory(int orderId)
        {
            Trace.TraceInformation("Step 3: Updating Inventory...");
            Trace.WriteLine("Inventory updated successfully.");
        }

        static void GenerateInvoice(int orderId)
        {
            Trace.TraceInformation("Step 4: Generating Invoice...");
            Trace.WriteLine("Invoice generated successfully.");
        }
    }
}
