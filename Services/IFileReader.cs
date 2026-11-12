namespace FileAnalyzerWinForm.Services
{
    public interface IFileReader
    {
        string SupportedExtension { get; }
        string ReadText(string filePath);
    }
}