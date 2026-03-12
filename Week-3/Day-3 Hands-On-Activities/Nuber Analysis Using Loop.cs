namespace Number_Analysis_Using_Loop
{
    class Program
    {
        static void Main()
        {
            int n;
            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            Console.Write("Enter Number: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                sum += i;

                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            Console.WriteLine("Even Count: " + evenCount);
            Console.WriteLine("Odd Count: " + oddCount);
            Console.WriteLine("Sum: " + sum);

            Console.ReadLine();
        }
    }
}
