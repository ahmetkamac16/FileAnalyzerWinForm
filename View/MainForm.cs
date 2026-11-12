using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileAnalyzerWinForm.Services;
using FileAnalyzerWinForm.Analysis;
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

                btnUpload.Enabled = false;
                cmbFileType.Enabled = false;
                progressBarAnalysis.Visible = true;

                try
                { 
                    AnalysisResult result = await Task.Run(() =>
                    {
                        IFileReader reader =
                            _fileReaderFactory.GetReader(filePath);

                        string text = reader.ReadText(filePath);

                        AnalysisResult analysisResult = new AnalysisResult
                        {
                            FilePath = filePath
                        };

                        TextAnalyzer textAnalyzer = new TextAnalyzer();
                        textAnalyzer.Analyze(text, analysisResult);

                        PunctuationAnalyzer punctuationAnalyzer =
                            new PunctuationAnalyzer();

                        punctuationAnalyzer.Analyze(text, analysisResult);

                        return analysisResult;
                    });

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
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "An error occurred while analyzing the file:\n"
                        + ex.Message,
                        "Analysis Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    progressBarAnalysis.Visible = false;
                    cmbFileType.Enabled = true;
                    btnUpload.Enabled = cmbFileType.SelectedIndex >= 0;
                }
            }
        }
    }
}
