using System;
using System.IO;
using System.Linq;
using System.Text;
using FileAnalyzerWinForm.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FileAnalyzerWinForm.Services
{
    public class JsonResultExporter : IResultExporter
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            DateFormatString = "yyyy-MM-dd'T'HH:mm:ss"
        };

        public string FileExtension => ".json";

        public void Export(AnalysisResult result, string filePath)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            var export = new
            {
                FileName = Path.GetFileName(result.FilePath),
                FilePath = result.FilePath,
                ExportedAt = DateTime.Now,
                TotalWordCount = result.TotalWordCount,
                DistinctWordCount = result.DistinctWordCount,
                RepeatedWords = result.WordFrequencies
                    .Where(pair => pair.Value > 1)
                    .OrderByDescending(pair => pair.Value)
                    .Select(pair => new { Word = pair.Key, Count = pair.Value }),
                Punctuation = result.PunctuationCounts
                    .OrderByDescending(pair => pair.Value)
                    .Select(pair => new { Symbol = pair.Key.ToString(), Count = pair.Value })
            };

            string json = JsonConvert.SerializeObject(export, Settings);

            File.WriteAllText(filePath, json, new UTF8Encoding(false));
        }
    }
}