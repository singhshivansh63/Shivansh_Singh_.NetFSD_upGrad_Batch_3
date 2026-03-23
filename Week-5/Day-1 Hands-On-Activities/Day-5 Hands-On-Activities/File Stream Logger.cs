using System;
using System.IO;
using System.Text;

namespace FileStreamLogger
{
    class Program
    {
        // Define the log file path
        private const string LogFilePath = "log_messages.txt";

        static void Main(string[] args)
        {
             
            Console.WriteLine($"Log file: {Path.GetFullPath(LogFilePath)}");
             

            bool continueLogging = true;

            while (continueLogging)
            {
                Console.Write("Enter message: ");
                string userInput = Console.ReadLine();

                // Check for exit condition
                if (userInput?.Trim().ToUpper() == "EXIT")
                {
                    continueLogging = false;
                    Console.WriteLine("\nExiting logger. Goodbye!");
                    break;
                }

                // Validate empty input
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("[WARNING] Empty message skipped. Please enter a valid message.\n");
                    continue;
                }

                // Write message to file
                WriteMessageToFile(userInput.Trim());
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        static void WriteMessageToFile(string message)
        {
            try
            {
                // Format message with a timestamp
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string formattedMessage = $"[{timestamp}] {message}{Environment.NewLine}";

                // Convert message string to bytes using UTF-8 encoding
                byte[] messageBytes = Encoding.UTF8.GetBytes(formattedMessage);

                // Open FileStream in Append mode so previous messages are not overwritten
                // FileMode.Append  → Opens file if it exists, creates it if not; positions at end
                // FileAccess.Write → Only write permission (no read needed here)
                using (FileStream fileStream = new FileStream(
                    LogFilePath,
                    FileMode.Append,
                    FileAccess.Write))
                {
                    // Write byte array to the file
                    fileStream.Write(messageBytes, 0, messageBytes.Length);

                    // Ensure data is flushed to the underlying storage
                    fileStream.Flush();
                }

                Console.WriteLine($"[SUCCESS] Message written to '{LogFilePath}'.\n");
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handles cases where the app lacks permission to write to the file
                Console.WriteLine($"[ERROR] Access denied: {ex.Message}");
                Console.WriteLine("Please check file permissions and try again.\n");
            }
            catch (DirectoryNotFoundException ex)
            {
                // Handles cases where the directory in the path does not exist
                Console.WriteLine($"[ERROR] Directory not found: {ex.Message}");
                Console.WriteLine("Please verify the file path is correct.\n");
            }
            catch (IOException ex)
            {
                // Handles general I/O errors (disk full, file locked, etc.)
                Console.WriteLine($"[ERROR] I/O Error occurred: {ex.Message}");
                Console.WriteLine("Please ensure the file is not locked by another process.\n");
            }
            catch (Exception ex)
            {
                // Catch-all for any other unexpected exceptions
                Console.WriteLine($"[ERROR] Unexpected error: {ex.Message}\n");
            }
        }
    }
}
