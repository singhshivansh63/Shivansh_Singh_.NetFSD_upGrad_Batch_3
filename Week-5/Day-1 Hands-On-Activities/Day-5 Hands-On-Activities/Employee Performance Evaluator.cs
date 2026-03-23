using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // 1. Accept inputs
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Monthly Sales Amount: ");
            double sales = double.Parse(Console.ReadLine());

            Console.Write("Enter Customer Rating (1-5): ");
            int rating = int.Parse(Console.ReadLine());

            // Validate input
            if (sales < 0 || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid input values!");
                return;
            }

            // 2. Get tuple result
            var result = GetPerformanceData(sales, rating);

            // 3. Pattern Matching using switch expression
            string performance = result switch
            {
                (var s, var r) when s >= 100000 && r >= 4 => "High Performer",
                (var s, var r) when s >= 50000 && r >= 3 => "Average Performer",
                _ => "Needs Improvement"
            };

            // 4. Display output
            Console.WriteLine("\n--- Employee Performance Report ---");
            Console.WriteLine("Employee Name : " + name);
            Console.WriteLine("Sales Amount  : " + result.sales);
            Console.WriteLine("Rating        : " + result.rating);
            Console.WriteLine("Performance   : " + performance);
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please enter valid numeric values.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }

    // Method returning Tuple
    static (double sales, int rating) GetPerformanceData(double sales, int rating)
    {
        return (sales, rating);
    }
}
