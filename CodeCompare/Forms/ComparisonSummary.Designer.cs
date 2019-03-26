namespace CodeCompare.Forms
{
    partial class ComparisonSummary
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
            this.lblMatch = new System.Windows.Forms.Label();
            this.lblLeftSideOnly = new System.Windows.Forms.Label();
            this.lblRightSideOnly = new System.Windows.Forms.Label();
            this.lblDifference = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new VistaButtonTest.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMatch
            // 
            this.lblMatch.AutoSize = true;
            this.lblMatch.BackColor = System.Drawing.Color.Transparent;
            this.lblMatch.Location = new System.Drawing.Point(100, 11);
            this.lblMatch.Name = "lblMatch";
            this.lblMatch.Size = new System.Drawing.Size(75, 13);
            this.lblMatch.TabIndex = 0;
            this.lblMatch.Text = "0 line(s) match";
            // 
            // lblLeftSideOnly
            // 
            this.lblLeftSideOnly.AutoSize = true;
            this.lblLeftSideOnly.BackColor = System.Drawing.Color.Transparent;
            this.lblLeftSideOnly.Location = new System.Drawing.Point(100, 38);
            this.lblLeftSideOnly.Name = "lblLeftSideOnly";
            this.lblLeftSideOnly.Size = new System.Drawing.Size(104, 13);
            this.lblLeftSideOnly.TabIndex = 1;
            this.lblLeftSideOnly.Text = "0 line(s) left side only";
            // 
            // lblRightSideOnly
            // 
            this.lblRightSideOnly.AutoSize = true;
            this.lblRightSideOnly.BackColor = System.Drawing.Color.Transparent;
            this.lblRightSideOnly.Location = new System.Drawing.Point(100, 65);
            this.lblRightSideOnly.Name = "lblRightSideOnly";
            this.lblRightSideOnly.Size = new System.Drawing.Size(110, 13);
            this.lblRightSideOnly.TabIndex = 2;
            this.lblRightSideOnly.Text = "0 line(s) right side only";
            // 
            // lblDifference
            // 
            this.lblDifference.AutoSize = true;
            this.lblDifference.BackColor = System.Drawing.Color.Transparent;
            this.lblDifference.Location = new System.Drawing.Point(100, 94);
            this.lblDifference.Name = "lblDifference";
            this.lblDifference.Size = new System.Drawing.Size(120, 13);
            this.lblDifference.TabIndex = 3;
            this.lblDifference.Text = "0 line(s) with differences";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::CodeCompare.Properties.Resources.CodeCompareLogo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.BaseColor = System.Drawing.Color.WhiteSmoke;
            this.btnOK.ButtonColor = System.Drawing.Color.DarkGray;
            this.btnOK.ButtonText = "OK";
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.GlowColor = System.Drawing.Color.DimGray;
            this.btnOK.Location = new System.Drawing.Point(167, 127);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 27);
            this.btnOK.TabIndex = 10;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ComparisonSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CodeCompare.Properties.Resources.GrayBackGroundArrow1;
            this.ClientSize = new System.Drawing.Size(279, 166);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDifference);
            this.Controls.Add(this.lblRightSideOnly);
            this.Controls.Add(this.lblLeftSideOnly);
            this.Controls.Add(this.lblMatch);
            this.Name = "ComparisonSummary";
            this.Text = "ComparisonSummary";
            this.Load += new System.EventHandler(this.ComparisonSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMatch;
        private System.Windows.Forms.Label lblLeftSideOnly;
        private System.Windows.Forms.Label lblRightSideOnly;
        private System.Windows.Forms.Label lblDifference;
        private System.Windows.Forms.PictureBox pictureBox1;
        private VistaButtonTest.VistaButton btnOK;
    }
}