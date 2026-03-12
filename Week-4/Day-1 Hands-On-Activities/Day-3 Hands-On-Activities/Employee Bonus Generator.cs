namespace Employee_Bonus_Calculator
{
    class Program
    {
        static void Main()
        {
            string name;
            double salary, bonus = 0;
            int experience;

            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Salary: ");
            salary = double.Parse(Console.ReadLine());

            Console.Write("Enter Experience (years): ");
            experience = int.Parse(Console.ReadLine());

             
            if (experience < 2)
            {
                bonus = salary * 0.05;
            }
            else if (experience >= 2 && experience <= 5)
            {
                bonus = salary * 0.10;
            }
            else
            {
                bonus = salary * 0.15;
            }
 

            double finalSalary = (bonus > 0) ? salary + bonus : salary;

            Console.WriteLine("\nEmployee: " + name);
            Console.WriteLine("Bonus: " + bonus.ToString("C"));
            Console.WriteLine("Final Salary: " + finalSalary.ToString("C"));

            Console.ReadLine();
        }
    }
}
