using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace FileAnalyzerWinForm.Services
{
    public class XlsxFileReader : IFileReader
    {
        public string SupportedExtension => ".xlsx";

        public string ReadText(string filePath)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var texts = workbook.Worksheets
                    .SelectMany(sheet => sheet.CellsUsed())
                    .Where(cell => cell.DataType == XLDataType.Text)
                    .Select(cell => cell.GetString())
                    .Where(text => !string.IsNullOrWhiteSpace(text));

                return string.Join(Environment.NewLine, texts);
            }
        }
    }
}
