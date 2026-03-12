namespace Student_Grade_Evaluator
{
    class Program
    {
        static void Main()
        {
            string name;
            int marks;

            Console.WriteLine("Enter Name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter Marks (0-100):");
            marks = int.Parse(Console.ReadLine());

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks! Please enter marks between 0 and 100.");
            }
            else
            {
                Console.WriteLine("Student: " + name);

                if (marks >= 90)
                {
                    Console.WriteLine("Grade: A");
                }
                else if (marks >= 75)
                {
                    Console.WriteLine("Grade: B");
                }
                else if (marks >= 60)
                {
                    Console.WriteLine("Grade: C");
                }
                else if (marks >= 40)
                {
                    Console.WriteLine("Grade: D");
                }
                else
                {
                    Console.WriteLine("Grade: Fail");
                }
            }

            Console.ReadLine();
        }
    }

}
