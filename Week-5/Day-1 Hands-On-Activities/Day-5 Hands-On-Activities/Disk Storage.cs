using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
       
            DriveInfo[] drives = DriveInfo.GetDrives();

            Console.WriteLine("\n--- Disk Storage Report ---\n");

            foreach (DriveInfo drive in drives)
            {
                try
                {
                 
                    if (!drive.IsReady)
                    {
                        Console.WriteLine("Drive Name : " + drive.Name);
                        Console.WriteLine("Status     : Not Ready");
                        Console.WriteLine("-----------------------------");
                        continue;
                    }

                    
                    double totalSize = drive.TotalSize;
                    double freeSpace = drive.AvailableFreeSpace;
                    double freePercent = (freeSpace / totalSize) * 100;

                    Console.WriteLine("Drive Name     : " + drive.Name);
                    Console.WriteLine("Drive Type     : " + drive.DriveType);
                    Console.WriteLine("Total Size     : " + (totalSize / (1024 * 1024 * 1024)) + " GB");
                    Console.WriteLine("Free Space     : " + (freeSpace / (1024 * 1024 * 1024)) + " GB");
                    Console.WriteLine("Free Space (%) : " + freePercent.ToString("F2") + "%");

                   
                    if (freePercent < 15)
                    {
                        Console.WriteLine("⚠ Warning: Low Disk Space!");
                    }

                    Console.WriteLine("-----------------------------");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Drive Name : " + drive.Name);
                    Console.WriteLine("Access Denied!");
                    Console.WriteLine("-----------------------------");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
