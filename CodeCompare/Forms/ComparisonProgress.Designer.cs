namespace CodeCompare.Forms
{
    partial class ComparisonProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparisonProgress));
            this.txtPath1 = new System.Windows.Forms.TextBox();
            this.txtPath2 = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.progressBarCompare = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblComparing = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.backgroundWorkerDifference = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // txtPath1
            // 
            this.txtPath1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.txtPath1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath1.Location = new System.Drawing.Point(12, 23);
            this.txtPath1.Name = "txtPath1";
            this.txtPath1.ReadOnly = true;
            this.txtPath1.Size = new System.Drawing.Size(433, 20);
            this.txtPath1.TabIndex = 1;
            this.txtPath1.TabStop = false;
            // 
            // txtPath2
            // 
            this.txtPath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.txtPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath2.Location = new System.Drawing.Point(12, 60);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.ReadOnly = true;
            this.txtPath2.Size = new System.Drawing.Size(433, 20);
            this.txtPath2.TabIndex = 3;
            this.txtPath2.TabStop = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(9, 44);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // progressBarCompare
            // 
            this.progressBarCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarCompare.BackColor = System.Drawing.Color.White;
            this.progressBarCompare.Location = new System.Drawing.Point(12, 100);
            this.progressBarCompare.Name = "progressBarCompare";
            this.progressBarCompare.Size = new System.Drawing.Size(433, 23);
            this.progressBarCompare.TabIndex = 5;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.Color.Transparent;
            this.lblProgress.Location = new System.Drawing.Point(9, 84);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(51, 13);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "Progress:";
            // 
            // lblComparing
            // 
            this.lblComparing.AutoSize = true;
            this.lblComparing.BackColor = System.Drawing.Color.Transparent;
            this.lblComparing.Location = new System.Drawing.Point(9, 7);
            this.lblComparing.Name = "lblComparing";
            this.lblComparing.Size = new System.Drawing.Size(120, 13);
            this.lblComparing.TabIndex = 0;
            this.lblComparing.Text = "Please Wait Comparing:";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(370, 129);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // backgroundWorkerDifference
            // 
            this.backgroundWorkerDifference.WorkerSupportsCancellation = true;
            this.backgroundWorkerDifference.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDifference_DoWork);
            this.backgroundWorkerDifference.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDifference_RunWorkerCompleted);
            this.backgroundWorkerDifference.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerDifference_ProgressChanged);
            // 
            // ComparisonProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.BackgroundImage = global::CodeCompare.Properties.Resources.GrayBackGroundArrow1;
            this.ClientSize = new System.Drawing.Size(457, 160);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblComparing);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBarCompare);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtPath1);
            this.Controls.Add(this.txtPath2);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComparisonProgress";
            this.ShowInTaskbar = false;
            this.Text = "Please Wait Comparing ...";
            this.Load += new System.EventHandler(this.CalculateDifference_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComparisonProgress_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath1;
        private System.Windows.Forms.TextBox txtPath2;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.ProgressBar progressBarCompare;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblComparing;
        private System.Windows.Forms.Button btnStop;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDifference;
    }
}