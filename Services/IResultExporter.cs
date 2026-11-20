using FileAnalyzerWinForm.Models;

namespace FileAnalyzerWinForm.Services
{
    public interface IResultExporter
    {
        string FileExtension { get; }

        void Export(AnalysisResult result, string filePath);
    }
}