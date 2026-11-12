using System;

namespace FileAnalyzerWinForm.Logging
{
    public interface ILogger
    {
        void Info(string message);
        void Error(string message, Exception exception);
    }
}