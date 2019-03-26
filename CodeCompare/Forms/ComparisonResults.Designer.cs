namespace CodeCompare.Forms
{
    partial class ComparisonResults
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparisonResults));
            this.columnHeaderLeftLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLeftName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLeftSize = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLeftType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLeftPath = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRightLine = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRightName = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRightSize = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRightType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRightPath = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderLeftLastWrite = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderRightLastWrite = new System.Windows.Forms.ColumnHeader();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDifferences = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentDifference = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelectedPath1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelectedPath2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAdditionalComparison = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressAddiditonal = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvFile1 = new FastListView.FastListView();
            this.mnuLeftFileAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuLeftCopyToOtherSide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftCopyAllToOtherSide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLeftSaveChangesAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftIgnoreLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLeftInsertLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLeftEditLines = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLeftTop = new System.Windows.Forms.Panel();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.lvFile2 = new FastListView.FastListView();
            this.mnuRightFileAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRightCopyAllToOtherSide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRightCopyToOtherSide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRightSaveChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRightSaveChangesAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRightIgnoreLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRightInsertLine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRightEditLines = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRightDeleteLines = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.summaryPanel = new SummaryPanel.SummaryPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnStartNewComparison = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCompare = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefreshFromDisk = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrevious = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnView = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDifferences = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSummary = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAbout = new System.Windows.Forms.ToolStripSplitButton();
            this.btnAboutShow = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.columnLeftLine = new System.Windows.Forms.ColumnHeader();
            this.columnLeftText = new System.Windows.Forms.ColumnHeader();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.mnuRightIOAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRightIOCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRightIOIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRightIODelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLeftIOAction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuLeftIOCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftIOIgnore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftIODelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuLeftIOSynchronize = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorkerCompleteProcess = new System.ComponentModel.BackgroundWorker();
            this.statusStrip.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.mnuLeftFileAction.SuspendLayout();
            this.pnlLeftTop.SuspendLayout();
            this.mnuRightFileAction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.mnuRightIOAction.SuspendLayout();
            this.mnuLeftIOAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblDifferences,
            this.lblCurrentDifference,
            this.lblSelectedPath1,
            this.lblSelectedPath2,
            this.lblAdditionalComparison,
            this.progressAddiditonal});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(857, 22);
            this.statusStrip.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(113, 17);
            this.lblStatus.Text = "Application Started ...";
            // 
            // lblDifferences
            // 
            this.lblDifferences.BackColor = System.Drawing.Color.Transparent;
            this.lblDifferences.Name = "lblDifferences";
            this.lblDifferences.Size = new System.Drawing.Size(75, 17);
            this.lblDifferences.Text = "Differences: 0";
            // 
            // lblCurrentDifference
            // 
            this.lblCurrentDifference.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentDifference.Name = "lblCurrentDifference";
            this.lblCurrentDifference.Size = new System.Drawing.Size(114, 17);
            this.lblCurrentDifference.Text = "Currently Displayed: 0";
            // 
            // lblSelectedPath1
            // 
            this.lblSelectedPath1.Name = "lblSelectedPath1";
            this.lblSelectedPath1.Size = new System.Drawing.Size(0, 17);
            // 
            // lblSelectedPath2
            // 
            this.lblSelectedPath2.Name = "lblSelectedPath2";
            this.lblSelectedPath2.Size = new System.Drawing.Size(0, 17);
            // 
            // lblAdditionalComparison
            // 
            this.lblAdditionalComparison.Name = "lblAdditionalComparison";
            this.lblAdditionalComparison.Size = new System.Drawing.Size(150, 17);
            this.lblAdditionalComparison.Text = "Performing Deep Comparison:";
            // 
            // progressAddiditonal
            // 
            this.progressAddiditonal.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressAddiditonal.Name = "progressAddiditonal";
            this.progressAddiditonal.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer.ContentPanel.Controls.Add(this.pnlLeft);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(857, 436);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(857, 461);
            this.toolStripContainer.TabIndex = 1;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.toolStripContainer.TopToolStripPanel.BackgroundImage = global::CodeCompare.Properties.Resources.GrayBackGround;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(21, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvFile1);
            this.splitContainer1.Panel1.Controls.Add(this.pnlLeftTop);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvFile2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(836, 436);
            this.splitContainer1.SplitterDistance = 414;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvFile1
            // 
            this.lvFile1.AllowDrop = true;
            this.lvFile1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvFile1.ContextMenuStrip = this.mnuLeftFileAction;
            this.lvFile1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFile1.ItemsChanged = false;
            this.lvFile1.Location = new System.Drawing.Point(0, 21);
            this.lvFile1.Name = "lvFile1";
            this.lvFile1.Size = new System.Drawing.Size(414, 415);
            this.lvFile1.TabIndex = 3;
            this.lvFile1.ListViewDoubleClick += new FastListView.FastListView.ListViewDoubleClickHandler(this.lvFile1_ListViewDoubleClick);
            this.lvFile1.ListViewDragDrop += new FastListView.FastListView.ListViewDragDropHandler(this.lvFile1_ListViewDragDrop);
            this.lvFile1.ListViewScroll += new FastListView.FastListView.ScrollBarVerticalHandler(this.lvFile1_Scroll);
            this.lvFile1.SelectedIndexChanged += new FastListView.FastListView.SelectedIndexChangedHandler(this.lvFile1_SelectedIndexChanged);
            // 
            // mnuLeftFileAction
            // 
            this.mnuLeftFileAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLeftCopyToOtherSide,
            this.toolStripSeparator3,
            this.mnuLeftCopyAllToOtherSide,
            this.toolStripSeparator11,
            this.mnuLeftSelectAll,
            this.toolStripSeparator16,
            this.mnuLeftSaveChanges,
            this.mnuLeftSaveChangesAs,
            this.toolStripSeparator9,
            this.mnuLeftIgnoreLines,
            this.mnuLeftInsertLine,
            this.mnuLeftEditLines,
            this.toolStripSeparator10,
            this.mnuLeftDelete});
            this.mnuLeftFileAction.Name = "mnuFileAction";
            this.mnuLeftFileAction.Size = new System.Drawing.Size(192, 232);
            // 
            // mnuLeftCopyToOtherSide
            // 
            this.mnuLeftCopyToOtherSide.BackColor = System.Drawing.SystemColors.Control;
            this.mnuLeftCopyToOtherSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuLeftCopyToOtherSide.ForeColor = System.Drawing.Color.Black;
            this.mnuLeftCopyToOtherSide.Image = ((System.Drawing.Image)(resources.GetObject("mnuLeftCopyToOtherSide.Image")));
            this.mnuLeftCopyToOtherSide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuLeftCopyToOtherSide.ImageTransparentColor = System.Drawing.Color.White;
            this.mnuLeftCopyToOtherSide.Name = "mnuLeftCopyToOtherSide";
            this.mnuLeftCopyToOtherSide.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftCopyToOtherSide.Text = "Copy to Other Side";
            this.mnuLeftCopyToOtherSide.Click += new System.EventHandler(this.mnuLeftCopyToOtherSide_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuLeftCopyAllToOtherSide
            // 
            this.mnuLeftCopyAllToOtherSide.BackColor = System.Drawing.SystemColors.Control;
            this.mnuLeftCopyAllToOtherSide.Image = ((System.Drawing.Image)(resources.GetObject("mnuLeftCopyAllToOtherSide.Image")));
            this.mnuLeftCopyAllToOtherSide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuLeftCopyAllToOtherSide.ImageTransparentColor = System.Drawing.Color.White;
            this.mnuLeftCopyAllToOtherSide.Name = "mnuLeftCopyAllToOtherSide";
            this.mnuLeftCopyAllToOtherSide.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftCopyAllToOtherSide.Text = "Copy All to Other Side";
            this.mnuLeftCopyAllToOtherSide.Click += new System.EventHandler(this.btnCopyAllToOtherSide_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuLeftSelectAll
            // 
            this.mnuLeftSelectAll.Name = "mnuLeftSelectAll";
            this.mnuLeftSelectAll.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftSelectAll.Text = "Select All";
            this.mnuLeftSelectAll.Click += new System.EventHandler(this.mnuLeftSelectAll_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuLeftSaveChanges
            // 
            this.mnuLeftSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("mnuLeftSaveChanges.Image")));
            this.mnuLeftSaveChanges.Name = "mnuLeftSaveChanges";
            this.mnuLeftSaveChanges.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftSaveChanges.Text = "Save Changes";
            this.mnuLeftSaveChanges.Click += new System.EventHandler(this.mnuLeftSaveChanges_Click);
            // 
            // mnuLeftSaveChangesAs
            // 
            this.mnuLeftSaveChangesAs.Image = ((System.Drawing.Image)(resources.GetObject("mnuLeftSaveChangesAs.Image")));
            this.mnuLeftSaveChangesAs.Name = "mnuLeftSaveChangesAs";
            this.mnuLeftSaveChangesAs.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftSaveChangesAs.Text = "Save Changes As";
            this.mnuLeftSaveChangesAs.Click += new System.EventHandler(this.mnuLeftSaveChangesAs_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuLeftIgnoreLines
            // 
            this.mnuLeftIgnoreLines.Image = global::CodeCompare.Properties.Resources._001_04;
            this.mnuLeftIgnoreLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuLeftIgnoreLines.Name = "mnuLeftIgnoreLines";
            this.mnuLeftIgnoreLines.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftIgnoreLines.Text = "Ignore Line(s)";
            this.mnuLeftIgnoreLines.Click += new System.EventHandler(this.mnuLeftIgnoreLines_Click);
            // 
            // mnuLeftInsertLine
            // 
            this.mnuLeftInsertLine.Image = global::CodeCompare.Properties.Resources._001_03;
            this.mnuLeftInsertLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuLeftInsertLine.Name = "mnuLeftInsertLine";
            this.mnuLeftInsertLine.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftInsertLine.Text = "Insert Line";
            this.mnuLeftInsertLine.Click += new System.EventHandler(this.mnuLeftInsertLine_Click);
            // 
            // mnuLeftEditLines
            // 
            this.mnuLeftEditLines.Image = global::CodeCompare.Properties.Resources._001_45;
            this.mnuLeftEditLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuLeftEditLines.Name = "mnuLeftEditLines";
            this.mnuLeftEditLines.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftEditLines.Text = "Edit Lines";
            this.mnuLeftEditLines.Click += new System.EventHandler(this.mnuLeftEditLines_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuLeftDelete
            // 
            this.mnuLeftDelete.Image = global::CodeCompare.Properties.Resources._001_29;
            this.mnuLeftDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuLeftDelete.Name = "mnuLeftDelete";
            this.mnuLeftDelete.Size = new System.Drawing.Size(191, 22);
            this.mnuLeftDelete.Text = "Delete Line(s)";
            this.mnuLeftDelete.Click += new System.EventHandler(this.mnuLeftDelete_Click);
            // 
            // pnlLeftTop
            // 
            this.pnlLeftTop.Controls.Add(this.txtFile1);
            this.pnlLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftTop.Name = "pnlLeftTop";
            this.pnlLeftTop.Size = new System.Drawing.Size(414, 21);
            this.pnlLeftTop.TabIndex = 0;
            // 
            // txtFile1
            // 
            this.txtFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.txtFile1.Location = new System.Drawing.Point(1, 0);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.ReadOnly = true;
            this.txtFile1.Size = new System.Drawing.Size(413, 20);
            this.txtFile1.TabIndex = 5;
            // 
            // lvFile2
            // 
            this.lvFile2.AllowDrop = true;
            this.lvFile2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvFile2.ContextMenuStrip = this.mnuRightFileAction;
            this.lvFile2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFile2.ItemsChanged = false;
            this.lvFile2.Location = new System.Drawing.Point(0, 21);
            this.lvFile2.Name = "lvFile2";
            this.lvFile2.Size = new System.Drawing.Size(418, 415);
            this.lvFile2.TabIndex = 1;
            this.lvFile2.ListViewDoubleClick += new FastListView.FastListView.ListViewDoubleClickHandler(this.lvFile2_ListViewDoubleClick);
            this.lvFile2.ListViewDragDrop += new FastListView.FastListView.ListViewDragDropHandler(this.lvFile2_ListViewDragDrop);
            this.lvFile2.ListViewScroll += new FastListView.FastListView.ScrollBarVerticalHandler(this.lvFile2_Scroll);
            this.lvFile2.SelectedIndexChanged += new FastListView.FastListView.SelectedIndexChangedHandler(this.lvFile2_SelectedIndexChanged);
            // 
            // mnuRightFileAction
            // 
            this.mnuRightFileAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRightCopyAllToOtherSide,
            this.toolStripSeparator12,
            this.mnuRightCopyToOtherSide,
            this.toolStripSeparator13,
            this.mnuSelectAll,
            this.toolStripSeparator18,
            this.mnuRightSaveChanges,
            this.mnuRightSaveChangesAs,
            this.toolStripSeparator4,
            this.mnuRightIgnoreLine,
            this.mnuRightInsertLine,
            this.mnuRightEditLines,
            this.toolStripSeparator5,
            this.mnuRightDeleteLines});
            this.mnuRightFileAction.Name = "mnuRightFileAction";
            this.mnuRightFileAction.Size = new System.Drawing.Size(192, 232);
            // 
            // mnuRightCopyAllToOtherSide
            // 
            this.mnuRightCopyAllToOtherSide.BackColor = System.Drawing.SystemColors.Control;
            this.mnuRightCopyAllToOtherSide.Image = ((System.Drawing.Image)(resources.GetObject("mnuRightCopyAllToOtherSide.Image")));
            this.mnuRightCopyAllToOtherSide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuRightCopyAllToOtherSide.ImageTransparentColor = System.Drawing.Color.White;
            this.mnuRightCopyAllToOtherSide.Name = "mnuRightCopyAllToOtherSide";
            this.mnuRightCopyAllToOtherSide.Size = new System.Drawing.Size(191, 22);
            this.mnuRightCopyAllToOtherSide.Text = "Copy All to Other Side";
            this.mnuRightCopyAllToOtherSide.Click += new System.EventHandler(this.mnuRightCopyAllToOtherSide_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuRightCopyToOtherSide
            // 
            this.mnuRightCopyToOtherSide.BackColor = System.Drawing.SystemColors.Control;
            this.mnuRightCopyToOtherSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuRightCopyToOtherSide.ForeColor = System.Drawing.Color.Black;
            this.mnuRightCopyToOtherSide.Image = ((System.Drawing.Image)(resources.GetObject("mnuRightCopyToOtherSide.Image")));
            this.mnuRightCopyToOtherSide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuRightCopyToOtherSide.ImageTransparentColor = System.Drawing.Color.White;
            this.mnuRightCopyToOtherSide.Name = "mnuRightCopyToOtherSide";
            this.mnuRightCopyToOtherSide.Size = new System.Drawing.Size(191, 22);
            this.mnuRightCopyToOtherSide.Text = "Copy to Other Side";
            this.mnuRightCopyToOtherSide.Click += new System.EventHandler(this.mnuRightCopyToOtherSide_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(191, 22);
            this.mnuSelectAll.Text = "Select All";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuRightSaveChanges
            // 
            this.mnuRightSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("mnuRightSaveChanges.Image")));
            this.mnuRightSaveChanges.Name = "mnuRightSaveChanges";
            this.mnuRightSaveChanges.Size = new System.Drawing.Size(191, 22);
            this.mnuRightSaveChanges.Text = "Save Changes";
            this.mnuRightSaveChanges.Click += new System.EventHandler(this.mnuRightSaveChanges_Click);
            // 
            // mnuRightSaveChangesAs
            // 
            this.mnuRightSaveChangesAs.Image = ((System.Drawing.Image)(resources.GetObject("mnuRightSaveChangesAs.Image")));
            this.mnuRightSaveChangesAs.Name = "mnuRightSaveChangesAs";
            this.mnuRightSaveChangesAs.Size = new System.Drawing.Size(191, 22);
            this.mnuRightSaveChangesAs.Text = "Save Changes As";
            this.mnuRightSaveChangesAs.Click += new System.EventHandler(this.mnuRightSaveChangesAs_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuRightIgnoreLine
            // 
            this.mnuRightIgnoreLine.Image = global::CodeCompare.Properties.Resources._001_04;
            this.mnuRightIgnoreLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRightIgnoreLine.Name = "mnuRightIgnoreLine";
            this.mnuRightIgnoreLine.Size = new System.Drawing.Size(191, 22);
            this.mnuRightIgnoreLine.Text = "Ignore Line(s)";
            this.mnuRightIgnoreLine.Click += new System.EventHandler(this.mnuRightIgnoreLine_Click);
            // 
            // mnuRightInsertLine
            // 
            this.mnuRightInsertLine.Image = global::CodeCompare.Properties.Resources._001_03;
            this.mnuRightInsertLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRightInsertLine.Name = "mnuRightInsertLine";
            this.mnuRightInsertLine.Size = new System.Drawing.Size(191, 22);
            this.mnuRightInsertLine.Text = "Insert Line";
            this.mnuRightInsertLine.Click += new System.EventHandler(this.mnuRightInsertLine_Click);
            // 
            // mnuRightEditLines
            // 
            this.mnuRightEditLines.Image = global::CodeCompare.Properties.Resources._001_45;
            this.mnuRightEditLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRightEditLines.Name = "mnuRightEditLines";
            this.mnuRightEditLines.Size = new System.Drawing.Size(191, 22);
            this.mnuRightEditLines.Text = "Edit Lines";
            this.mnuRightEditLines.Click += new System.EventHandler(this.mnuRightEditLines_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(188, 6);
            // 
            // mnuRightDeleteLines
            // 
            this.mnuRightDeleteLines.Image = global::CodeCompare.Properties.Resources._001_29;
            this.mnuRightDeleteLines.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuRightDeleteLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRightDeleteLines.Name = "mnuRightDeleteLines";
            this.mnuRightDeleteLines.Size = new System.Drawing.Size(191, 22);
            this.mnuRightDeleteLines.Text = "Delete Line(s)";
            this.mnuRightDeleteLines.Click += new System.EventHandler(this.btnDeleteLines_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFile2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 21);
            this.panel1.TabIndex = 0;
            // 
            // txtFile2
            // 
            this.txtFile2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.txtFile2.Location = new System.Drawing.Point(1, 1);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.ReadOnly = true;
            this.txtFile2.Size = new System.Drawing.Size(417, 20);
            this.txtFile2.TabIndex = 7;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.pnlLeft.Controls.Add(this.summaryPanel);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(21, 436);
            this.pnlLeft.TabIndex = 1;
            this.pnlLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeft_Paint);
            // 
            // summaryPanel
            // 
            this.summaryPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.summaryPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(242)))), ((int)(((byte)(231)))));
            this.summaryPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.summaryPanel.Location = new System.Drawing.Point(0, 21);
            this.summaryPanel.Name = "summaryPanel";
            this.summaryPanel.Size = new System.Drawing.Size(21, 394);
            this.summaryPanel.TabIndex = 0;
            this.summaryPanel.SummaryPanelMouseDown += new SummaryPanel.SummaryPanel.MouseDownHandler(this.summaryPanel_SummaryPanelMouseDown);
            // 
            // toolStrip
            // 
            this.toolStrip.BackgroundImage = global::CodeCompare.Properties.Resources.GrayBackGround;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.toolStripSeparator7,
            this.btnCompare,
            this.toolStripSeparator14,
            this.btnRefresh,
            this.toolStripSeparator2,
            this.btnRefreshFromDisk,
            this.toolStripSeparator15,
            this.btnPrevious,
            this.btnNext,
            this.toolStripSeparator1,
            this.btnView,
            this.toolStripSeparator6,
            this.btnAbout});
            this.toolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(521, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // btnFile
            // 
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStartNewComparison,
            this.toolStripSeparator8,
            this.btnClose});
            this.btnFile.Image = global::CodeCompare.Properties.Resources.open;
            this.btnFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(52, 22);
            this.btnFile.Text = "File";
            // 
            // btnStartNewComparison
            // 
            this.btnStartNewComparison.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnStartNewComparison.Image = global::CodeCompare.Properties.Resources._001_09;
            this.btnStartNewComparison.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStartNewComparison.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStartNewComparison.Name = "btnStartNewComparison";
            this.btnStartNewComparison.Size = new System.Drawing.Size(192, 22);
            this.btnStartNewComparison.Text = "Start New Comparison";
            this.btnStartNewComparison.Click += new System.EventHandler(this.btnStartNewComparison_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(189, 6);
            // 
            // btnClose
            // 
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(192, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCompare
            // 
            this.btnCompare.Image = global::CodeCompare.Properties.Resources._001_09;
            this.btnCompare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(70, 22);
            this.btnCompare.Text = "Compare";
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::CodeCompare.Properties.Resources._001_39;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 22);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnRefreshFromDisk
            // 
            this.btnRefreshFromDisk.Image = global::CodeCompare.Properties.Resources._001_39;
            this.btnRefreshFromDisk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshFromDisk.Name = "btnRefreshFromDisk";
            this.btnRefreshFromDisk.Size = new System.Drawing.Size(114, 22);
            this.btnRefreshFromDisk.Text = "Refresh From Disk";
            this.btnRefreshFromDisk.Click += new System.EventHandler(this.btnRefreshFromFile_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.ImageTransparentColor = System.Drawing.Color.White;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(23, 22);
            this.btnPrevious.Text = "<";
            this.btnPrevious.ToolTipText = "Previous Difference";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageTransparentColor = System.Drawing.Color.White;
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(23, 22);
            this.btnNext.Text = ">";
            this.btnNext.ToolTipText = "Next Difference";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnView
            // 
            this.btnView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAll,
            this.btnDifferences,
            this.toolStripSeparator20,
            this.mnuSummary});
            this.btnView.Image = global::CodeCompare.Properties.Resources._001_37;
            this.btnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(58, 22);
            this.btnView.Text = "View";
            // 
            // btnAll
            // 
            this.btnAll.Checked = true;
            this.btnAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(140, 22);
            this.btnAll.Text = "All";
            this.btnAll.Click += new System.EventHandler(this.btnAllTool_Click);
            // 
            // btnDifferences
            // 
            this.btnDifferences.Name = "btnDifferences";
            this.btnDifferences.Size = new System.Drawing.Size(140, 22);
            this.btnDifferences.Text = "Differences";
            this.btnDifferences.Click += new System.EventHandler(this.btnDifferences_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(137, 6);
            // 
            // mnuSummary
            // 
            this.mnuSummary.Name = "mnuSummary";
            this.mnuSummary.Size = new System.Drawing.Size(140, 22);
            this.mnuSummary.Text = "Summary";
            this.mnuSummary.Click += new System.EventHandler(this.mnuSummary_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAbout
            // 
            this.btnAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAboutShow});
            this.btnAbout.Image = global::CodeCompare.Properties.Resources._001_50;
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(68, 22);
            this.btnAbout.Text = "&About";
            this.btnAbout.ButtonClick += new System.EventHandler(this.btnAbout_ButtonClick);
            // 
            // btnAboutShow
            // 
            this.btnAboutShow.Image = global::CodeCompare.Properties.Resources._001_50;
            this.btnAboutShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAboutShow.Name = "btnAboutShow";
            this.btnAboutShow.Size = new System.Drawing.Size(114, 22);
            this.btnAboutShow.Text = "About";
            this.btnAboutShow.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // columnLeftLine
            // 
            this.columnLeftLine.Text = "Line";
            // 
            // columnLeftText
            // 
            this.columnLeftText.Text = "Text(Source)";
            // 
            // mnuRightIOAction
            // 
            this.mnuRightIOAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRightIOCopyPath,
            this.toolStripSeparator17,
            this.mnuRightIOIgnore,
            this.toolStripSeparator19,
            this.mnuRightIODelete});
            this.mnuRightIOAction.Name = "mnuRightFileAction";
            this.mnuRightIOAction.Size = new System.Drawing.Size(178, 82);
            // 
            // mnuRightIOCopyPath
            // 
            this.mnuRightIOCopyPath.BackColor = System.Drawing.SystemColors.Control;
            this.mnuRightIOCopyPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuRightIOCopyPath.ForeColor = System.Drawing.Color.Black;
            this.mnuRightIOCopyPath.Image = ((System.Drawing.Image)(resources.GetObject("mnuRightIOCopyPath.Image")));
            this.mnuRightIOCopyPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuRightIOCopyPath.ImageTransparentColor = System.Drawing.Color.White;
            this.mnuRightIOCopyPath.Name = "mnuRightIOCopyPath";
            this.mnuRightIOCopyPath.Size = new System.Drawing.Size(177, 22);
            this.mnuRightIOCopyPath.Text = "Copy to Other Side";
            this.mnuRightIOCopyPath.Click += new System.EventHandler(this.mnuRightIOCopyPath_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuRightIOIgnore
            // 
            this.mnuRightIOIgnore.Image = global::CodeCompare.Properties.Resources._001_04;
            this.mnuRightIOIgnore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRightIOIgnore.Name = "mnuRightIOIgnore";
            this.mnuRightIOIgnore.Size = new System.Drawing.Size(177, 22);
            this.mnuRightIOIgnore.Text = "Ignore";
            this.mnuRightIOIgnore.Click += new System.EventHandler(this.mnuRightIOIgnore_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuRightIODelete
            // 
            this.mnuRightIODelete.Image = global::CodeCompare.Properties.Resources._001_29;
            this.mnuRightIODelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuRightIODelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRightIODelete.Name = "mnuRightIODelete";
            this.mnuRightIODelete.Size = new System.Drawing.Size(177, 22);
            this.mnuRightIODelete.Text = "Delete";
            this.mnuRightIODelete.Click += new System.EventHandler(this.mnuRightIODelete_Click);
            // 
            // mnuLeftIOAction
            // 
            this.mnuLeftIOAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLeftIOCopyPath,
            this.toolStripSeparator22,
            this.mnuLeftIOIgnore,
            this.toolStripSeparator23,
            this.mnuLeftIODelete,
            this.toolStripSeparator21,
            this.mnuLeftIOSynchronize});
            this.mnuLeftIOAction.Name = "mnuFileAction";
            this.mnuLeftIOAction.Size = new System.Drawing.Size(178, 110);
            // 
            // mnuLeftIOCopyPath
            // 
            this.mnuLeftIOCopyPath.BackColor = System.Drawing.SystemColors.Control;
            this.mnuLeftIOCopyPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuLeftIOCopyPath.ForeColor = System.Drawing.Color.Black;
            this.mnuLeftIOCopyPath.Image = ((System.Drawing.Image)(resources.GetObject("mnuLeftIOCopyPath.Image")));
            this.mnuLeftIOCopyPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuLeftIOCopyPath.ImageTransparentColor = System.Drawing.Color.White;
            this.mnuLeftIOCopyPath.Name = "mnuLeftIOCopyPath";
            this.mnuLeftIOCopyPath.Size = new System.Drawing.Size(177, 22);
            this.mnuLeftIOCopyPath.Text = "Copy to Other Side";
            this.mnuLeftIOCopyPath.Click += new System.EventHandler(this.mnuLeftIOCopyPath_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuLeftIOIgnore
            // 
            this.mnuLeftIOIgnore.Image = global::CodeCompare.Properties.Resources._001_04;
            this.mnuLeftIOIgnore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuLeftIOIgnore.Name = "mnuLeftIOIgnore";
            this.mnuLeftIOIgnore.Size = new System.Drawing.Size(177, 22);
            this.mnuLeftIOIgnore.Text = "Ignore";
            this.mnuLeftIOIgnore.Click += new System.EventHandler(this.mnuLeftIOIgnore_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuLeftIODelete
            // 
            this.mnuLeftIODelete.Image = global::CodeCompare.Properties.Resources._001_29;
            this.mnuLeftIODelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuLeftIODelete.Name = "mnuLeftIODelete";
            this.mnuLeftIODelete.Size = new System.Drawing.Size(177, 22);
            this.mnuLeftIODelete.Text = "Delete";
            this.mnuLeftIODelete.Click += new System.EventHandler(this.mnuLeftIODelete_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuLeftIOSynchronize
            // 
            this.mnuLeftIOSynchronize.Image = global::CodeCompare.Properties.Resources.RightArrowSingleSmall;
            this.mnuLeftIOSynchronize.ImageTransparentColor = System.Drawing.Color.White;
            this.mnuLeftIOSynchronize.Name = "mnuLeftIOSynchronize";
            this.mnuLeftIOSynchronize.Size = new System.Drawing.Size(177, 22);
            this.mnuLeftIOSynchronize.Text = "Synchronize All";
            this.mnuLeftIOSynchronize.Click += new System.EventHandler(this.mnuLeftIOSynchronize_Click);
            // 
            // backgroundWorkerCompleteProcess
            // 
            this.backgroundWorkerCompleteProcess.WorkerReportsProgress = true;
            this.backgroundWorkerCompleteProcess.WorkerSupportsCancellation = true;
            this.backgroundWorkerCompleteProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCompleteProcess_DoWork);
            this.backgroundWorkerCompleteProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerCompleteProcess_RunWorkerCompleted);
            this.backgroundWorkerCompleteProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerCompleteProcess_ProgressChanged);
            // 
            // ComparisonResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(857, 461);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStripContainer);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComparisonResults";
            this.Text = "Code Compare - Comparison Results";
            this.Load += new System.EventHandler(this.FileComparisonResults_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComparisonResults_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.mnuLeftFileAction.ResumeLayout(false);
            this.pnlLeftTop.ResumeLayout(false);
            this.pnlLeftTop.PerformLayout();
            this.mnuRightFileAction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.mnuRightIOAction.ResumeLayout(false);
            this.mnuLeftIOAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlLeftTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblDifferences;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentDifference;
        private System.Windows.Forms.ToolStripButton btnPrevious;
        private System.Windows.Forms.ToolStripButton btnNext;
        private FastListView.FastListView lvFile1;
        private System.Windows.Forms.ColumnHeader columnLeftLine;
        private System.Windows.Forms.ColumnHeader columnLeftText;
        private FastListView.FastListView lvFile2;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ContextMenuStrip mnuLeftFileAction;
        private SummaryPanel.SummaryPanel summaryPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip mnuRightFileAction;
        private System.Windows.Forms.ToolStripMenuItem mnuRightSaveChanges;
        private System.Windows.Forms.ToolStripButton btnCompare;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftCopyAllToOtherSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuRightDeleteLines;
        private System.Windows.Forms.ToolStripMenuItem mnuRightEditLines;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton btnView;
        private System.Windows.Forms.ToolStripMenuItem btnAll;
        private System.Windows.Forms.ToolStripMenuItem btnDifferences;

        private System.Windows.Forms.ColumnHeader columnHeaderLeftLine;
        private System.Windows.Forms.ColumnHeader columnHeaderLeftName;
        private System.Windows.Forms.ColumnHeader columnHeaderLeftSize;
        private System.Windows.Forms.ColumnHeader columnHeaderLeftType;
        private System.Windows.Forms.ColumnHeader columnHeaderLeftPath;
        private System.Windows.Forms.ColumnHeader columnHeaderRightLine;
        private System.Windows.Forms.ColumnHeader columnHeaderRightName;
        private System.Windows.Forms.ColumnHeader columnHeaderRightType;
        private System.Windows.Forms.ColumnHeader columnHeaderRightSize;
        private System.Windows.Forms.ColumnHeader columnHeaderRightPath;
        private System.Windows.Forms.ColumnHeader columnHeaderLeftLastWrite;
        private System.Windows.Forms.ColumnHeader columnHeaderRightLastWrite;
        
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedPath1;
        private System.Windows.Forms.ToolStripMenuItem mnuRightIgnoreLine;
        private System.Windows.Forms.ToolStripMenuItem mnuRightSaveChangesAs;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem mnuRightInsertLine;
        private System.Windows.Forms.ToolStripStatusLabel lblSelectedPath2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSplitButton btnAbout;
        private System.Windows.Forms.ToolStripMenuItem btnAboutShow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripDropDownButton btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnStartNewComparison;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem btnClose;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftCopyToOtherSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftInsertLine;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftIgnoreLines;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftEditLines;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftSaveChanges;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftSaveChangesAs;
        private System.Windows.Forms.ToolStripMenuItem mnuRightCopyAllToOtherSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem mnuRightCopyToOtherSide;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton btnRefreshFromDisk;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ContextMenuStrip mnuRightIOAction;
        private System.Windows.Forms.ToolStripMenuItem mnuRightIOCopyPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripMenuItem mnuRightIOIgnore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem mnuRightIODelete;
        private System.Windows.Forms.ContextMenuStrip mnuLeftIOAction;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftIOCopyPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator22;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftIOIgnore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator23;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftIODelete;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator18;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem mnuSummary;
        private System.Windows.Forms.ToolStripMenuItem mnuLeftIOSynchronize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator21;
        private System.ComponentModel.BackgroundWorker backgroundWorkerCompleteProcess;
        private System.Windows.Forms.ToolStripProgressBar progressAddiditonal;
        private System.Windows.Forms.ToolStripStatusLabel lblAdditionalComparison;
       
    }
}