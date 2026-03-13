using System;

namespace HRSystem
{
    public class Employee
    {
        // Private fields
        private string _employeeId;
        private string _fullName;
        private int _age;
        private decimal _salary;

        // Property for Employee ID (Read Only)
        public string EmployeeId
        {
            get { return _employeeId; }
        }

        // Property for Name
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Name cannot be empty");

                _fullName = value;
            }
        }

        // Property for Age
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 18)
                    throw new Exception("Age must be greater than 18");

                _age = value;
            }
        }

        // Property for Salary (Read Only)
        public decimal Salary
        {
            get { return _salary; }
        }

        // Constructor with parameters
        public Employee(string empId, string name, int age, decimal salary)
        {
            if (string.IsNullOrWhiteSpace(empId))
                throw new Exception("Employee ID cannot be empty");

            if (salary < 1000)
                throw new Exception("Salary cannot be less than 1000");

            _employeeId = empId;
            FullName = name;
            Age = age;
            _salary = salary;
        }

        // Method to increase salary
        public void GiveRaise(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Raise amount must be greater than 0");

            _salary = _salary + amount;

            Console.WriteLine("Salary increased by: " + amount);
            Console.WriteLine("New Salary: " + _salary);
        }

        // Method to deduct penalty
        public void DeductPenalty(decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Penalty must be greater than 0");

            if (_salary - amount < 1000)
                throw new Exception("Salary cannot go below 1000");

            _salary = _salary - amount;

            Console.WriteLine("Penalty deducted: " + amount);
            Console.WriteLine("New Salary: " + _salary);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Creating object
                Employee emp = new Employee("E101", "Rahul", 30, 5000);

                Console.WriteLine("Employee ID: " + emp.EmployeeId);
                Console.WriteLine("Name: " + emp.FullName);
                Console.WriteLine("Age: " + emp.Age);
                Console.WriteLine("Salary: " + emp.Salary);

                Console.WriteLine();

                 
                emp.GiveRaise(1000);

                Console.WriteLine();

              
                emp.DeductPenalty(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}



