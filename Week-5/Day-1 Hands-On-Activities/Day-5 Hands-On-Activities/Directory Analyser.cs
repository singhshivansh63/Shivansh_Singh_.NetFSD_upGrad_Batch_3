using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter root directory path: ");
            string path = Console.ReadLine();

            // Check if directory exists
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            // Create DirectoryInfo object
            DirectoryInfo dir = new DirectoryInfo(path);

            // Get all subdirectories
            DirectoryInfo[] subDirs = dir.GetDirectories();

            Console.WriteLine("\n--- Directory Analysis ---\n");

            foreach (DirectoryInfo subDir in subDirs)
            {
                try
                {
                    // Count files in each directory
                    FileInfo[] files = subDir.GetFiles();
                    int fileCount = files.Length;

                    Console.WriteLine("Folder Name : " + subDir.Name);
                    Console.WriteLine("File Count  : " + fileCount);
                    Console.WriteLine("-----------------------------");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Folder Name : " + subDir.Name);
                    Console.WriteLine("Access Denied!");
                    Console.WriteLine("-----------------------------");
                }
            }

            Console.WriteLine("\nTotal Folders: " + subDirs.Length);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Error: Directory not found.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
