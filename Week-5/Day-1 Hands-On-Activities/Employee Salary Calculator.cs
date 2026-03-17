using System;

class Employee
{
    // Properties
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    // Virtual Method
    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

// Derived Class: Manager
class Manager : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.20);
    }
}

// Derived Class: Developer
class Developer : Employee
{
    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.10);
    }
}

class Program
{
    static void Main()
    {
        // Base class reference (Polymorphism)
        Employee emp;

        // Manager Object
        emp = new Manager();
        emp.Name = "Rahul";
        emp.BaseSalary = 50000;
        Console.WriteLine("Manager Salary = " + emp.CalculateSalary());

        // Developer Object
        emp = new Developer();
        emp.Name = "Aman";
        emp.BaseSalary = 50000;
        Console.WriteLine("Developer Salary = " + emp.CalculateSalary());
    }
}