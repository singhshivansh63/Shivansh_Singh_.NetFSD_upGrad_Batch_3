using System;

namespace DiscountCalculatorDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Product Discount Calculator ===\n");

            
            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.Write("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            
            double finalPrice = CalculateFinalPrice(price, discount);

            Console.WriteLine($"\nProduct: {productName}");
            Console.WriteLine($"Original Price: {price}");
            Console.WriteLine($"Discount: {discount}%");
            Console.WriteLine($"Final Price: {finalPrice}");

            Console.ReadLine();
        }
         
        static double CalculateFinalPrice(double price, double discount)
        {
            double discountAmount = price * discount / 100;
            double finalPrice = price - discountAmount;
            return finalPrice;
        }
    }
}
