using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileAnalyzerWinForm.Services;
using FileAnalyzerWinForm.Analysis;
using FileAnalyzerWinForm.Exceptions;
using FileAnalyzerWinForm.Models;
using FileAnalyzerWinForm.Logging;

namespace FileAnalyzerWinForm.View
{
    public partial class MainForm : Form
    {
        private readonly FileReaderFactory _fileReaderFactory =
            new FileReaderFactory();

        private readonly ILogger _logger = new FileLogger();

        public MainForm()
        {
            InitializeComponent();

            cmbFileType.Items.AddRange(
                _fileReaderFactory.SupportedExtensions.ToArray()
            );

            btnUpload.Enabled = false;
            progressBarAnalysis.Visible = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void cmbFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUpload.Enabled = cmbFileType.SelectedIndex >= 0;
        }

        private async void btnUpload_Click(object sender, EventArgs e)
        {
            if (cmbFileType.SelectedItem == null)
            {
                MessageBox.Show(
                    "Please select a file type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string selectedExtension = cmbFileType.SelectedItem.ToString();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a file to analyze";
                openFileDialog.Filter =
                    $"Selected Files (*{selectedExtension})|*{selectedExtension}";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string filePath = openFileDialog.FileName;

                SetBusy(true);

                await ExceptionHandler.ExecuteAsync(async () =>
                {
                    AnalysisResult result = await Task.Run(() => AnalyzeFile(filePath));

                    DisplayResult(result);

                    _logger.Info($"File successfully analyzed: {filePath}");
                    return true;
                },
                ex =>
                {
                    _logger.Error($"File analysis failed: {filePath}", ex);

                    MessageBox.Show(
                        "The selected file could not be analyzed.\n" +
                        "Please make sure the file is valid and try again.",
                        "Analysis Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return false;
                });

                SetBusy(false);
            }
        }
        private AnalysisResult AnalyzeFile(string filePath)
        {
            IFileReader reader = _fileReaderFactory.GetReader(filePath);

            string text = ExceptionHandler.Execute(
                () => reader.ReadText(filePath),
                ex => throw new FileReadException(filePath, ex));

            AnalysisResult analysisResult = new AnalysisResult
            {
                FilePath = filePath
            };

            new TextAnalyzer().Analyze(text, analysisResult);
            new PunctuationAnalyzer().Analyze(text, analysisResult);

            return analysisResult;
        }

        private void DisplayResult(AnalysisResult result)
        {
            lblUniqueWordCount.Text =
                $"Unique Words: {result.DistinctWordCount}";

            dgvRepeatedWords.DataSource = result.WordFrequencies
                .Where(pair => pair.Value > 1)
                .OrderByDescending(pair => pair.Value)
                .Select(pair => new
                {
                    Word = pair.Key,
                    Count = pair.Value
                })
                .ToList();

            dgvPunctuation.DataSource = result.PunctuationCounts
                .OrderByDescending(pair => pair.Value)
                .Select(pair => new
                {
                    Symbol = pair.Key.ToString(),
                    Count = pair.Value
                })
                .ToList();
        }

        private void SetBusy(bool busy)
        {
            progressBarAnalysis.Visible = busy;
            cmbFileType.Enabled = !busy;
            btnUpload.Enabled = !busy && cmbFileType.SelectedIndex >= 0;
        }
    }
}
