namespace Simple_Calculator
{
    class Program
    {
        static void Main()
        {
            double num1, num2;
            char op;

            Console.WriteLine("Enter First Number:");
            num1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Second Number:");
            num2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Operator (+, -, *, /):");
            op = char.Parse(Console.ReadLine());

            switch (op)
            {
                case '+':
                    Console.WriteLine("Result: " + (num1 + num2));
                    break;

                case '-':
                    Console.WriteLine("Result: " + (num1 - num2));
                    break;

                case '*':
                    Console.WriteLine("Result: " + (num1 * num2));
                    break;

                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by Zero is not allowed");
                    }
                    else
                    {
                        Console.WriteLine("Result: " + (num1 / num2));
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Operator!");
                    break;
            }

            Console.ReadLine();
        }
    }
}
