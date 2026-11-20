using System;
using System.IO;
using FileAnalyzerWinForm.Exceptions;
namespace FileAnalyzerWinForm.Logging
{
    public class FileLogger : ILogger
    {
        private readonly string _logFilePath;

        public FileLogger()
        {
            string logDirectory = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Logs"
            );

            Directory.CreateDirectory(logDirectory);

            string fileName = $"log_{DateTime.Now:yyyy-MM-dd}.txt";

            _logFilePath = Path.Combine(logDirectory, fileName);
        }

        public void Info(string message)
        {
            Write("INFO", message);
        }

        public void Error(string message, Exception exception)
        {
            string detail = $"{exception.GetType().Name}: {exception.Message}";

            if (exception.InnerException != null)
            {
                detail += $" --> {exception.InnerException.GetType().Name}: {exception.InnerException.Message}";
            }

            Write("ERROR", $"{message} | {detail}");
        }

        private void Write(string level, string message)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string line = $"[{timestamp}] [{level}] {message}";

            ExceptionHandler.Execute(() =>
            {
                File.AppendAllText(_logFilePath, line + Environment.NewLine);
                return true;
            },
            _ => false);
        }
    }
}