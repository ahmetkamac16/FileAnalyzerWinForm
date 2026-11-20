namespace FileAnalyzerWinForm.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblFileType = new System.Windows.Forms.Label();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.progressBarAnalysis = new System.Windows.Forms.ProgressBar();
            this.lblUniqueWordCount = new System.Windows.Forms.Label();
            this.dgvRepeatedWords = new System.Windows.Forms.DataGridView();
            this.dgvPunctuation = new System.Windows.Forms.DataGridView();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExportJson = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepeatedWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPunctuation)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFileType.Location = new System.Drawing.Point(35, 115);
            this.lblFileType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(74, 20);
            this.lblFileType.TabIndex = 0;
            this.lblFileType.Text = "File Type:";
            // 
            // cmbFileType
            // 
            this.cmbFileType.BackColor = System.Drawing.Color.White;
            this.cmbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFileType.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbFileType.ForeColor = System.Drawing.Color.MidnightBlue;
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Location = new System.Drawing.Point(165, 110);
            this.cmbFileType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(690, 28);
            this.cmbFileType.TabIndex = 1;
            this.cmbFileType.SelectedIndexChanged += new System.EventHandler(this.cmbFileType_SelectedIndexChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.Enabled = false;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumBlue;
            this.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(875, 108);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(130, 40);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // progressBarAnalysis
            // 
            this.progressBarAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarAnalysis.Location = new System.Drawing.Point(35, 625);
            this.progressBarAnalysis.Margin = new System.Windows.Forms.Padding(4);
            this.progressBarAnalysis.MarqueeAnimationSpeed = 30;
            this.progressBarAnalysis.Name = "progressBarAnalysis";
            this.progressBarAnalysis.Size = new System.Drawing.Size(970, 20);
            this.progressBarAnalysis.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarAnalysis.TabIndex = 3;
            // 
            // lblUniqueWordCount
            // 
            this.lblUniqueWordCount.AutoSize = true;
            this.lblUniqueWordCount.BackColor = System.Drawing.Color.Transparent;
            this.lblUniqueWordCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUniqueWordCount.Location = new System.Drawing.Point(35, 180);
            this.lblUniqueWordCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUniqueWordCount.Name = "lblUniqueWordCount";
            this.lblUniqueWordCount.Size = new System.Drawing.Size(166, 21);
            this.lblUniqueWordCount.TabIndex = 4;
            this.lblUniqueWordCount.Text = "Unique Word Count:";
            // 
            // dgvRepeatedWords
            // 
            this.dgvRepeatedWords.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvRepeatedWords.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvRepeatedWords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRepeatedWords.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRepeatedWords.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvRepeatedWords.ColumnHeadersHeight = 35;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRepeatedWords.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvRepeatedWords.EnableHeadersVisualStyles = false;
            this.dgvRepeatedWords.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvRepeatedWords.Location = new System.Drawing.Point(35, 220);
            this.dgvRepeatedWords.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRepeatedWords.Name = "dgvRepeatedWords";
            this.dgvRepeatedWords.ReadOnly = true;
            this.dgvRepeatedWords.RowHeadersVisible = false;
            this.dgvRepeatedWords.Size = new System.Drawing.Size(970, 170);
            this.dgvRepeatedWords.TabIndex = 5;
            // 
            // dgvPunctuation
            // 
            this.dgvPunctuation.AllowUserToAddRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvPunctuation.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvPunctuation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPunctuation.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(232)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPunctuation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPunctuation.ColumnHeadersHeight = 35;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPunctuation.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPunctuation.EnableHeadersVisualStyles = false;
            this.dgvPunctuation.GridColor = System.Drawing.Color.LightSteelBlue;
            this.dgvPunctuation.Location = new System.Drawing.Point(35, 420);
            this.dgvPunctuation.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPunctuation.Name = "dgvPunctuation";
            this.dgvPunctuation.ReadOnly = true;
            this.dgvPunctuation.RowHeadersVisible = false;
            this.dgvPunctuation.Size = new System.Drawing.Size(970, 175);
            this.dgvPunctuation.TabIndex = 6;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1034, 85);
            this.pnlHeader.TabIndex = 7;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(35, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(192, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "File Analyzer";
            // 
            // btnExportJson
            // 
            this.btnExportJson.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnExportJson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportJson.Enabled = false;
            this.btnExportJson.FlatAppearance.BorderSize = 0;
            this.btnExportJson.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumBlue;
            this.btnExportJson.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DodgerBlue;
            this.btnExportJson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportJson.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExportJson.ForeColor = System.Drawing.Color.White;
            this.btnExportJson.Location = new System.Drawing.Point(875, 170);
            this.btnExportJson.Name = "btnExportJson";
            this.btnExportJson.Size = new System.Drawing.Size(130, 40);
            this.btnExportJson.TabIndex = 8;
            this.btnExportJson.Text = "Export";
            this.btnExportJson.UseVisualStyleBackColor = false;
            this.btnExportJson.Click += new System.EventHandler(this.btnExportJson_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1034, 671);
            this.Controls.Add(this.btnExportJson);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.dgvPunctuation);
            this.Controls.Add(this.dgvRepeatedWords);
            this.Controls.Add(this.lblUniqueWordCount);
            this.Controls.Add(this.progressBarAnalysis);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.cmbFileType);
            this.Controls.Add(this.lblFileType);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1050, 710);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepeatedWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPunctuation)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileType;
        private System.Windows.Forms.ComboBox cmbFileType;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.ProgressBar progressBarAnalysis;
        private System.Windows.Forms.Label lblUniqueWordCount;
        private System.Windows.Forms.DataGridView dgvRepeatedWords;
        private System.Windows.Forms.DataGridView dgvPunctuation;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnExportJson;
    }
}

