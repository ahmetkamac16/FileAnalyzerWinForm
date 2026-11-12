namespace FileAnalyzerWinForm
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
            this.lblFileType = new System.Windows.Forms.Label();
            this.cmbFileType = new System.Windows.Forms.ComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.progressBarAnalysis = new System.Windows.Forms.ProgressBar();
            this.lblUniqueWordCount = new System.Windows.Forms.Label();
            this.dgvRepeatedWords = new System.Windows.Forms.DataGridView();
            this.dgvPunctuation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepeatedWords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPunctuation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileType
            // 
            this.lblFileType.AutoSize = true;
            this.lblFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFileType.Location = new System.Drawing.Point(37, 33);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.Size = new System.Drawing.Size(104, 24);
            this.lblFileType.TabIndex = 0;
            this.lblFileType.Text = "File Type:";
            // 
            // cmbFileType
            // 
            this.cmbFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileType.FormattingEnabled = true;
            this.cmbFileType.Location = new System.Drawing.Point(166, 36);
            this.cmbFileType.Name = "cmbFileType";
            this.cmbFileType.Size = new System.Drawing.Size(722, 21);
            this.cmbFileType.TabIndex = 1;
            this.cmbFileType.SelectedIndexChanged += new System.EventHandler(this.cmbFileType_SelectedIndexChanged);
            // 
            // btnUpload
            // 
            this.btnUpload.Enabled = false;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUpload.Location = new System.Drawing.Point(917, 33);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(93, 29);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // progressBarAnalysis
            // 
            this.progressBarAnalysis.Location = new System.Drawing.Point(41, 81);
            this.progressBarAnalysis.MarqueeAnimationSpeed = 30;
            this.progressBarAnalysis.Name = "progressBarAnalysis";
            this.progressBarAnalysis.Size = new System.Drawing.Size(969, 23);
            this.progressBarAnalysis.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarAnalysis.TabIndex = 3;
            this.progressBarAnalysis.Visible = false;
            // 
            // lblUniqueWordCount
            // 
            this.lblUniqueWordCount.AutoSize = true;
            this.lblUniqueWordCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblUniqueWordCount.Location = new System.Drawing.Point(38, 155);
            this.lblUniqueWordCount.Name = "lblUniqueWordCount";
            this.lblUniqueWordCount.Size = new System.Drawing.Size(144, 16);
            this.lblUniqueWordCount.TabIndex = 4;
            this.lblUniqueWordCount.Text = "Unique Word Count:";
            // 
            // dgvRepeatedWords
            // 
            this.dgvRepeatedWords.AllowUserToAddRows = false;
            this.dgvRepeatedWords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRepeatedWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepeatedWords.Location = new System.Drawing.Point(63, 192);
            this.dgvRepeatedWords.Name = "dgvRepeatedWords";
            this.dgvRepeatedWords.ReadOnly = true;
            this.dgvRepeatedWords.Size = new System.Drawing.Size(915, 150);
            this.dgvRepeatedWords.TabIndex = 5;
            // 
            // dgvPunctuation
            // 
            this.dgvPunctuation.AllowUserToAddRows = false;
            this.dgvPunctuation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPunctuation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPunctuation.Location = new System.Drawing.Point(63, 386);
            this.dgvPunctuation.Name = "dgvPunctuation";
            this.dgvPunctuation.ReadOnly = true;
            this.dgvPunctuation.Size = new System.Drawing.Size(915, 260);
            this.dgvPunctuation.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 681);
            this.Controls.Add(this.dgvPunctuation);
            this.Controls.Add(this.dgvRepeatedWords);
            this.Controls.Add(this.lblUniqueWordCount);
            this.Controls.Add(this.progressBarAnalysis);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.cmbFileType);
            this.Controls.Add(this.lblFileType);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepeatedWords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPunctuation)).EndInit();
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
    }
}

