using System;
using System.IO;

namespace ExibitionDAL
{
    public static class Logger
    {
        private static readonly string logFilePath = @"C:\Users\PC\source\repos\LabWork01\ExibitionDAL\Log_info.txt";

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
