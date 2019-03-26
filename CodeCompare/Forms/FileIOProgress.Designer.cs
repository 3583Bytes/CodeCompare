namespace CodeCompare.Forms
{
    partial class FileIOProgress
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
            this.CopyWorker = new System.ComponentModel.BackgroundWorker();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblCopySource = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBarCompare = new System.Windows.Forms.ProgressBar();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtPath1 = new System.Windows.Forms.TextBox();
            this.txtPath2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CopyWorker
            // 
            this.CopyWorker.WorkerReportsProgress = true;
            this.CopyWorker.WorkerSupportsCancellation = true;
            this.CopyWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CopyWorker_DoWork);
            this.CopyWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.CopyWorker_RunWorkerCompleted);
            this.CopyWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.CopyWorker_ProgressChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(373, 131);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblCopySource
            // 
            this.lblCopySource.AutoSize = true;
            this.lblCopySource.BackColor = System.Drawing.Color.Transparent;
            this.lblCopySource.Location = new System.Drawing.Point(12, 9);
            this.lblCopySource.Name = "lblCopySource";
            this.lblCopySource.Size = new System.Drawing.Size(105, 13);
            this.lblCopySource.TabIndex = 7;
            this.lblCopySource.Text = "Please Wait Copying";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Location = new System.Drawing.Point(12, 86);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(78, 13);
            this.lblProgress.TabIndex = 11;
            this.lblProgress.Text = "Total Progress:";
            // 
            // progressBarCompare
            // 
            this.progressBarCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarCompare.BackColor = System.Drawing.Color.White;
            this.progressBarCompare.Location = new System.Drawing.Point(15, 102);
            this.progressBarCompare.Name = "progressBarCompare";
            this.progressBarCompare.Size = new System.Drawing.Size(433, 23);
            this.progressBarCompare.TabIndex = 12;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(12, 46);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 9;
            this.lblTo.Text = "To:";
            // 
            // txtPath1
            // 
            this.txtPath1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.txtPath1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath1.Location = new System.Drawing.Point(15, 25);
            this.txtPath1.Name = "txtPath1";
            this.txtPath1.ReadOnly = true;
            this.txtPath1.Size = new System.Drawing.Size(433, 20);
            this.txtPath1.TabIndex = 8;
            this.txtPath1.TabStop = false;
            // 
            // txtPath2
            // 
            this.txtPath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.txtPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath2.Location = new System.Drawing.Point(15, 62);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.ReadOnly = true;
            this.txtPath2.Size = new System.Drawing.Size(433, 20);
            this.txtPath2.TabIndex = 10;
            this.txtPath2.TabStop = false;
            // 
            // FileIOProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 160);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblCopySource);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBarCompare);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtPath1);
            this.Controls.Add(this.txtPath2);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileIOProgress";
            this.Text = "Copy Progress";
            this.Load += new System.EventHandler(this.FileIOProgress_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker CopyWorker;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblCopySource;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBarCompare;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtPath1;
        private System.Windows.Forms.TextBox txtPath2;
    }
}