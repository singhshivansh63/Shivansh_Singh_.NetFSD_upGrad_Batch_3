using System;
using System.Collections.Generic;

 
record Student(int RollNo, string Name, string Course, int Marks);

class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        int choice;

        do
        {
            Console.WriteLine("\n--- Student Record Management ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddStudent(students);
                    break;

                case 2:
                    DisplayStudents(students);
                    break;

                case 3:
                    SearchStudent(students);
                    break;

                case 4:
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 4);
    }

     
    static void AddStudent(List<Student> students)
    {
        try
        {
            Console.Write("Enter Roll Number: ");
            int roll = int.Parse(Console.ReadLine());
            if (roll <= 0) throw new Exception("Invalid Roll Number!");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = int.Parse(Console.ReadLine());
            if (marks < 0 || marks > 100) throw new Exception("Marks must be between 0-100!");

            students.Add(new Student(roll, name, course, marks));

            Console.WriteLine("Student Added Successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

  
    static void DisplayStudents(List<Student> students)
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No records found!");
            return;
        }

        Console.WriteLine("\nStudent Records:");
        foreach (var s in students)
        {
            Console.WriteLine($"Roll No: {s.RollNo} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
        }
    }

   
    static void SearchStudent(List<Student> students)
    {
        Console.Write("Enter Roll Number to Search: ");
        int roll = int.Parse(Console.ReadLine());

        var student = students.Find(s => s.RollNo == roll);

        if (student != null)
        {
            Console.WriteLine("Student Found:");
            Console.WriteLine($"Roll No: {student.RollNo} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
        }
        else
        {
            Console.WriteLine("Record Not Found!");
        }
    }
}

