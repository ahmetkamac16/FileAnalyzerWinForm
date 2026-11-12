using System.IO;
using System.Text;

namespace FileAnalyzerWinForm.Readers
{
    public class TxtFileReader : IFileReader
    {
        public string SupportedExtension => ".txt";

        public string ReadText(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.UTF8);
        }
    }
}