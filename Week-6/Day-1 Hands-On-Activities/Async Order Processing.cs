using System;
using System.Threading.Tasks;

namespace AsyncOrderProcessing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== Order Processing Started ===\n");

            int orderId = 101;

            await ProcessOrderAsync(orderId);

            Console.WriteLine("\n=== Order Processing Completed ===");
            Console.ReadLine();
        }

       
        public static async Task ProcessOrderAsync(int orderId)
        {
            Console.WriteLine($"Processing Order ID: {orderId}\n");

            bool isPaymentVerified = await VerifyPaymentAsync(orderId);

            if (!isPaymentVerified)
            {
                Console.WriteLine("Payment Failed. Order Cancelled.");
                return;
            }

            bool isStockAvailable = await CheckInventoryAsync(orderId);

            if (!isStockAvailable)
            {
                Console.WriteLine("Out of Stock. Order Cancelled.");
                return;
            }

            
            await ConfirmOrderAsync(orderId);
        }

     
        public static async Task<bool> VerifyPaymentAsync(int orderId)
        {
            Console.WriteLine("Verifying payment...");
            await Task.Delay(2000); 

            Console.WriteLine("Payment Verified ");
            return true;  
        }

        
        public static async Task<bool> CheckInventoryAsync(int orderId)
        {
            Console.WriteLine("Checking inventory...");
            await Task.Delay(3000);  

            Console.WriteLine("Inventory Available ");
            return true;  
        }

         
        public static async Task ConfirmOrderAsync(int orderId)
        {
            Console.WriteLine("Confirming order...");
            await Task.Delay(1500);  

            Console.WriteLine($"Order ID {orderId} Confirmed ");
        }
    }
}
