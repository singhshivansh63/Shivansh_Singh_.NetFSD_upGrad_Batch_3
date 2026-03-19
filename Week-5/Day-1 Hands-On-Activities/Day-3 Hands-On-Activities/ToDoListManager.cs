using System;
using System.Collections.Generic;

class ToDoListManager
{
    static void Main(string[] args)
    {
        List<string> tasks = new List<string>();
        bool running = true;    

        do
        {
            DisplayMenu();

            string choice = Console.ReadLine();    

            switch (choice)
            {
                case "1":
                    AddTask(tasks);
                    break;

                case "2":
                    ViewTasks(tasks);
                    break;

                case "3":
                    RemoveTask(tasks);
                    break;

                case "4":
                    running = false;    
                    Console.WriteLine("\nGoodbye! Stay productive!");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please choose 1, 2, 3, or 4.");
                    break;
            }

        } while (running);
    }
 
    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("==============================");
        Console.WriteLine("      To-Do List Manager      ");
        Console.WriteLine("==============================");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. View Tasks");
        Console.WriteLine("3. Remove Task");
        Console.WriteLine("4. Exit");
        Console.WriteLine("------------------------------");
        Console.Write("Choose an option: ");
    }

    static void AddTask(List<string> tasks)
    {
        Console.Write("Enter task: ");
        string description = Console.ReadLine();

        
        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("\nTask description cannot be empty. Task not added.");
            return;   
        }

        tasks.Add(description.Trim());

        Console.WriteLine("\nTask added!");
    }
 
    static void ViewTasks(List<string> tasks)
    {
      
        if (tasks.Count == 0)
        {
            Console.WriteLine("\nYour to-do list is empty.");
            return;
        }

        Console.WriteLine("\nTasks:");

        
        for (int i = 0; i < tasks.Count; i++)
        {
            
            Console.WriteLine($"  {i + 1}. {tasks[i]}");
        }
    }

   
    static void RemoveTask(List<string> tasks)
    {
      
        if (tasks.Count == 0)
        {
            Console.WriteLine("\nNo tasks to remove. Your list is empty.");
            return;
        }

         
        ViewTasks(tasks);

        Console.Write("\nEnter task number to remove: ");
        string input = Console.ReadLine();
 
        if (!int.TryParse(input, out int taskNumber))
        {
            Console.WriteLine("\nInvalid input. Please enter a numeric task number.");
            return;
        }

       
        int index = taskNumber - 1;
      
        if (index < 0 || index >= tasks.Count)
        {
            Console.WriteLine("\nInvalid task number.");
            return;
        }

        
        string removedTask = tasks[index];
        tasks.RemoveAt(index);
        Console.WriteLine($"\nRemoved: {removedTask}");
    }
}
