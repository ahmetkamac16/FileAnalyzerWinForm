using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UglyToad.PdfPig;

namespace FileAnalyzerWinForm.Services
{
    public class PdfFileReader : IFileReader
    {
        public string SupportedExtension => ".pdf";

        public string ReadText(string filePath)
        {
            using (var document = PdfDocument.Open(filePath))
            {
                var pages = document.GetPages()
                    .Select(page => string.Join(" ", page.GetWords().Select(word => word.Text)));

                return string.Join(Environment.NewLine, pages);
            }
        }
    }
}
