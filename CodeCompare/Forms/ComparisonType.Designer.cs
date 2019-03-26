namespace CodeCompare.Forms
{
    partial class ComparisonType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparisonType));
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.rdoFolders = new System.Windows.Forms.RadioButton();
            this.rdoFiles = new System.Windows.Forms.RadioButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAboutShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCompare = new VistaButtonTest.VistaButton();
            this.txtPath1 = new System.Windows.Forms.TextBox();
            this.btnPath2 = new System.Windows.Forms.Button();
            this.txtPath2 = new System.Windows.Forms.TextBox();
            this.btnPath1 = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.InitialDirectory = "Desktop";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.pnlTop);
            this.pnlMain.Controls.Add(this.btnCompare);
            this.pnlMain.Controls.Add(this.txtPath1);
            this.pnlMain.Controls.Add(this.btnPath2);
            this.pnlMain.Controls.Add(this.txtPath2);
            this.pnlMain.Controls.Add(this.btnPath1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(464, 135);
            this.pnlMain.TabIndex = 6;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Transparent;
            this.pnlTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTop.Controls.Add(this.rdoFolders);
            this.pnlTop.Controls.Add(this.rdoFiles);
            this.pnlTop.Controls.Add(this.toolStrip);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(464, 26);
            this.pnlTop.TabIndex = 2;
            // 
            // rdoFolders
            // 
            this.rdoFolders.AutoSize = true;
            this.rdoFolders.BackColor = System.Drawing.Color.Transparent;
            this.rdoFolders.Checked = true;
            this.rdoFolders.Location = new System.Drawing.Point(284, 5);
            this.rdoFolders.Name = "rdoFolders";
            this.rdoFolders.Size = new System.Drawing.Size(59, 17);
            this.rdoFolders.TabIndex = 0;
            this.rdoFolders.TabStop = true;
            this.rdoFolders.Text = "Folders";
            this.rdoFolders.UseVisualStyleBackColor = false;
            // 
            // rdoFiles
            // 
            this.rdoFiles.AutoSize = true;
            this.rdoFiles.BackColor = System.Drawing.Color.Transparent;
            this.rdoFiles.Location = new System.Drawing.Point(232, 5);
            this.rdoFiles.Name = "rdoFiles";
            this.rdoFiles.Size = new System.Drawing.Size(46, 17);
            this.rdoFiles.TabIndex = 1;
            this.rdoFiles.Text = "Files";
            this.rdoFiles.UseVisualStyleBackColor = false;
            // 
            // toolStrip
            // 
            this.toolStrip.BackgroundImage = global::CodeCompare.Properties.Resources.GrayBackGround;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.toolStripSeparator1,
            this.btnAbout,
            this.toolStripSeparator3});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(146, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // btnFile
            // 
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose});
            this.btnFile.ImageTransparentColor = System.Drawing.Color.White;
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(38, 22);
            this.btnFile.Text = "File";
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(180, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAbout
            // 
            this.btnAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAboutShow});
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(53, 22);
            this.btnAbout.Text = "About";
            // 
            // btnAboutShow
            // 
            this.btnAboutShow.Image = global::CodeCompare.Properties.Resources._001_50;
            this.btnAboutShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAboutShow.Name = "btnAboutShow";
            this.btnAboutShow.Size = new System.Drawing.Size(180, 22);
            this.btnAboutShow.Text = "About";
            this.btnAboutShow.Click += new System.EventHandler(this.btnAboutShow_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.BackColor = System.Drawing.Color.Transparent;
            this.btnCompare.BaseColor = System.Drawing.Color.DarkGray;
            this.btnCompare.ButtonColor = System.Drawing.Color.WhiteSmoke;
            this.btnCompare.ButtonText = "Compare";
            this.btnCompare.ForeColor = System.Drawing.Color.Black;
            this.btnCompare.GlowColor = System.Drawing.Color.Gray;
            this.btnCompare.HighlightColor = System.Drawing.Color.WhiteSmoke;
            this.btnCompare.Location = new System.Drawing.Point(24, 101);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(406, 27);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // txtPath1
            // 
            this.txtPath1.AllowDrop = true;
            this.txtPath1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath1.BackColor = System.Drawing.Color.White;
            this.txtPath1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath1.Location = new System.Drawing.Point(24, 41);
            this.txtPath1.Name = "txtPath1";
            this.txtPath1.Size = new System.Drawing.Size(406, 20);
            this.txtPath1.TabIndex = 0;
            this.txtPath1.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPath1_DragDrop);
            this.txtPath1.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPath1_DragEnter);
            // 
            // btnPath2
            // 
            this.btnPath2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath2.BackgroundImage = global::CodeCompare.Properties.Resources.open;
            this.btnPath2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPath2.Location = new System.Drawing.Point(432, 67);
            this.btnPath2.Name = "btnPath2";
            this.btnPath2.Size = new System.Drawing.Size(29, 25);
            this.btnPath2.TabIndex = 3;
            this.btnPath2.UseVisualStyleBackColor = true;
            this.btnPath2.Click += new System.EventHandler(this.btnPath2_Click);
            // 
            // txtPath2
            // 
            this.txtPath2.AllowDrop = true;
            this.txtPath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath2.BackColor = System.Drawing.Color.White;
            this.txtPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPath2.Location = new System.Drawing.Point(24, 70);
            this.txtPath2.Name = "txtPath2";
            this.txtPath2.Size = new System.Drawing.Size(406, 20);
            this.txtPath2.TabIndex = 1;
            this.txtPath2.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtPath2_DragDrop);
            this.txtPath2.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtPath2_DragEnter);
            // 
            // btnPath1
            // 
            this.btnPath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPath1.BackgroundImage = global::CodeCompare.Properties.Resources.open;
            this.btnPath1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPath1.Location = new System.Drawing.Point(432, 37);
            this.btnPath1.Name = "btnPath1";
            this.btnPath1.Size = new System.Drawing.Size(29, 25);
            this.btnPath1.TabIndex = 2;
            this.btnPath1.UseVisualStyleBackColor = true;
            this.btnPath1.Click += new System.EventHandler(this.btnPath1_Click);
            // 
            // ComparisonType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.BackgroundImage = global::CodeCompare.Properties.Resources.GrayBackGroundArrow1;
            this.ClientSize = new System.Drawing.Size(464, 135);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComparisonType";
            this.Text = "Code Compare";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComparisonType_FormClosing);
            this.Load += new System.EventHandler(this.ComparisonType_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.RadioButton rdoFolders;
        private System.Windows.Forms.RadioButton rdoFiles;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripDropDownButton btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton btnAbout;
        private System.Windows.Forms.ToolStripMenuItem btnAboutShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private VistaButtonTest.VistaButton btnCompare;
        private System.Windows.Forms.TextBox txtPath1;
        private System.Windows.Forms.Button btnPath2;
        private System.Windows.Forms.TextBox txtPath2;
        private System.Windows.Forms.Button btnPath1;
    }
}