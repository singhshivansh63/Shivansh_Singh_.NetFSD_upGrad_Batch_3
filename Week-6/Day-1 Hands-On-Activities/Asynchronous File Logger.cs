using System;using System.Threading.Tasks;namespace AsyncFileLogger{    class Program    {        static async Task Main(string[] args)        {            Console.WriteLine("Application Started...\n");

            // Calling async logging multiple times
            Task log1 = WriteLogAsync("User logged in");            Task log2 = WriteLogAsync("File uploaded");            Task log3 = WriteLogAsync("Error occurred");            Task log4 = WriteLogAsync("User logged out");            Console.WriteLine("Logs are being written asynchronously...\n");

            // Wait for all logging tasks to complete
            await Task.WhenAll(log1, log2, log3, log4);            Console.WriteLine("\nAll logs written successfully!");            Console.ReadLine();        }

        // Asynchronous method to simulate file writing
        public static async Task WriteLogAsync(string message)        {            Console.WriteLine($"Start writing log: {message}");

            // Simulate file I/O delay
            await Task.Delay(2000);            Console.WriteLine($"Finished writing log: {message}");        }    }}
