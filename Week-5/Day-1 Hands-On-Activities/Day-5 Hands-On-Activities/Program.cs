using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter folder path: ");
            string folderPath = Console.ReadLine();

            // Check if directory exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

            // Get all files from directory
            string[] files = Directory.GetFiles(folderPath);

            int fileCount = 0;

            Console.WriteLine("\nFile Details:\n");

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                Console.WriteLine("File Name   : " + fileInfo.Name);
                Console.WriteLine("File Size   : " + fileInfo.Length + " bytes");
                Console.WriteLine("Created On  : " + fileInfo.CreationTime);
                Console.WriteLine("-----------------------------------");

                fileCount++;
            }

            Console.WriteLine("\nTotal Files: " + fileCount);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied to the folder.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Error: Directory not found.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
