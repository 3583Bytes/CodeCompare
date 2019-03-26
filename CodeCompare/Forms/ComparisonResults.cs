using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CodeCompare.Shared;
using CompareEngine;
using FastListView;


namespace CodeCompare.Forms
{
    public partial class ComparisonResults : BaseForm
    {
        #region Delegates

        public delegate void RefreshAndCloseDelegate();

        #endregion

        private readonly ArrayList DifferenceLines;
        private readonly string FilePath1;
        private readonly string FilePath2;
        private readonly List<CompareItem> ListFiles1;
        private readonly List<CompareItem> ListFiles2;
         private readonly PathType comparisonPathType;
        private readonly Summary summary;
        private int CopyWindows;
        private DateTime EndTime;

        private string SelectedPath1;
        private string SelectedPath2;


        private DateTime StartTime;
        private int currentDifferenceLine;
        public RefreshAndCloseDelegate refreshAndCloseDelegate;

        #region Constructors

        public ComparisonResults
            (
            List<CompareItem> listFiles1,
            List<CompareItem> listFiles2,
            ArrayList differenceLines,
            DateTime startTime,
            string filePath1,
            string filePath2,
            PathType pathType,
            Summary Summary
            )
        {
            InitializeComponent();

            refreshAndCloseDelegate = new RefreshAndCloseDelegate(RefreshAndClose);


            var fileInfo = new FileCompareInfo();

            fileInfo.ComparePathType = PathType.ListItems;

            fileInfo.ListViewItems1 = listFiles1;
            fileInfo.ListViewItems2 = listFiles2;

            CopyWindows = 0;
            
            comparisonPathType = pathType;

            if (pathType == PathType.Directory)
            {
                mnuLeftFileAction.Enabled = false;
                mnuRightFileAction.Enabled = false;

                lvFile1.ContextMenuStrip = mnuLeftIOAction;
                lvFile2.ContextMenuStrip = mnuRightIOAction;

                lvFile1.Clear();

                columnHeaderLeftLine.Text = "Line";
                columnHeaderLeftName.Text = "Name";
                columnHeaderLeftSize.Text = "Size";
                columnHeaderLeftType.Text = "Type";
                columnHeaderLeftPath.Text = "Path";
                columnHeaderLeftLastWrite.Text = "LastWrite";

                lvFile1.Columns.AddRange
                    (
                        new[]
                            {
                                columnHeaderLeftLine,
                                columnHeaderLeftName,
                                columnHeaderLeftSize,
                                columnHeaderLeftType,
                                columnHeaderLeftPath,
                                columnHeaderLeftLastWrite
                            }
                    );


                lvFile2.Clear();


                columnHeaderRightLine.Text = "Line";
                columnHeaderRightName.Text = "Name";
                columnHeaderRightSize.Text = "Size";
                columnHeaderRightType.Text = "Type";
                columnHeaderRightPath.Text = "Path";
                columnHeaderRightLastWrite.Text = "LastWrite";

                lvFile2.Columns.AddRange
                    (
                        new[]
                            {
                                columnHeaderRightLine,
                                columnHeaderRightName,
                                columnHeaderRightSize,
                                columnHeaderRightType,
                                columnHeaderRightPath,
                                columnHeaderRightLastWrite
                            }
                    );
            }

            ListFiles1 = listFiles1;
            ListFiles2 = listFiles2;

            currentDifferenceLine = 0;
            DifferenceLines = differenceLines;

            FilePath1 = filePath1;
            FilePath2 = filePath2;

            txtFile1.Text = filePath1;
            txtFile2.Text = filePath2;

            StartTime = startTime;

            if (pathType == PathType.Directory)
            {
                btnCompare.Text = "Compare";
                btnCompare.ToolTipText = "Compare";
            }
            else
            {
                btnCompare.Enabled = false;
                btnCompare.Visible = false;
            }

            summary = Summary;
        }

        #endregion Constructors

        public void RefreshAndClose()
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }

            CopyWindows--;

            if (CopyWindows <= 0)
            {
                txtFile1.Text = FilePath1;
                txtFile2.Text = FilePath2;
                ComparePath();
                CloseForm();
            }
        }

        private void mnuLeftIOSynchronize_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }
            
            txtFile1.Text = FilePath1;
            txtFile2.Text = FilePath2;

            lvFile2.SelectAllItems();

           


            if (
                MessageBox.Show(
                    "Do you want to replace all contents in:\n\n" + FilePath2 + "\n\nWith contents from: \n\n" +
                    FilePath1, "Synchronize Files", MessageBoxButtons.YesNo) ==
                DialogResult.No)
            {
                return;
            }

            foreach (CompareItem item in lvFile2.AllItems)
            {
                item.Selected = false;

                if (item.CompareResultTag == CompareItem.CompareResult.Equal)
                {
                    continue;
                }
                if (item.CompareResultTag == CompareItem.CompareResult.Ignore)
                {
                    continue;
                }

                if (item.SubItems.Count < 5)
                {
                    continue;
                }

                if (item.SubItems[4] == null)
                {
                    continue;
                }
                if (item.SubItems[1] == null)
                {
                    continue;
                }
                if (String.IsNullOrEmpty(item.SubItems[4].Text))
                {
                    continue;
                }
                if (String.IsNullOrEmpty(item.SubItems[1].Text))
                {
                    continue;
                }

                string path = item.SubItems[4].Text + @"\" + item.SubItems[1].Text;

                if (ValidFile(path))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;


                        //Check the file actually exists
                        if (File.Exists(path))
                        {
                            //If its readonly set it back to normal   //Need to "AND" it as it can also be archive, hidden etc 
                            if ((File.GetAttributes(path) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                File.SetAttributes(path, FileAttributes.Normal);
                            //Delete the file
                            File.Delete(path);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Cannot Delete File", MessageBoxButtons.OK);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    path = item.SubItems[4].Text;

                    if (ValidDirectory(path))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;


                            foreach (string p in Directory.GetFiles(path))
                            {
                                //If its readonly set it back to normal   //Need to "AND" it as it can also be archive, hidden etc 
                                if ((File.GetAttributes(p) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                    File.SetAttributes(p, FileAttributes.Normal);
                            }

                            Directory.Delete(path, true);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Cannot Delete Directory", MessageBoxButtons.OK);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                        }
                    }
                }
            }


            lvFile2.Refresh();
         
            lvFile1.SelectAllItems();

            foreach (ListViewItem item in lvFile1.SelectedItems)
            {
                if (item.ToolTipText == "Original Equal")
                {
                    item.Selected = false;
                }
            }

            lvFile1.Refresh();


            IOCopyAllFilesFromLefttoRight();
        }

        public void FinishComparison()
        {
            backgroundWorkerCompleteProcess.RunWorkerAsync(lvFile1.AllItems);
        }

        

        private void backgroundWorkerCompleteProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CompareText destinationDiffList = new CompareText();
                CompareText sourceDiffList = new CompareText();
                ArrayList resultLines;
            

                int count = 0;

                List<CompareItem> allItems = (List<CompareItem>) e.Argument;

                foreach (CompareItem item in allItems)
                {
                    count++;

                    backgroundWorkerCompleteProcess.ReportProgress((int)(((decimal)count / allItems.Count) * 100));

                    if (item.CompareResultTag != CompareItem.CompareResult.Equal)
                    {
                        continue;
                    }

                    string line1 = FilePath1 + "\\" + item.SubItems[1].Text;
                    string line2 = FilePath2 + "\\" + item.SubItems[1].Text;

                    if (item.SubItems[3].Text != "File")
                    {

                        List<CompareEngine.DirectoryItem> sourceDirectoryListing = DirectoryHelper.GetDirectoryInfo(line1);
                        List<DirectoryItem> destinationDirectoryListing = DirectoryHelper.GetDirectoryInfo(line2);

                        sourceDiffList = new CompareText(sourceDirectoryListing);
                        destinationDiffList = new CompareText(destinationDirectoryListing);

                    }
                    else if (item.SubItems[3].Text == "File")
                    {
                   
                        var fileInfo = new FileInfo(line1);

                        if (fileInfo.Exists)
                        {
                            sourceDiffList = new CompareText(line1);
                        }
                        else
                        {
                            sourceDiffList = new CompareText();
                        }

                        fileInfo = new FileInfo(line2);

                        if (fileInfo.Exists)
                        {
                            destinationDiffList = new CompareText(line2);
                        }
                        else
                        {
                            destinationDiffList = new CompareText();
                        }
                    }

                    var compareEngine = new CompareEngine.CompareEngine();
                    compareEngine.StartDiff(sourceDiffList, destinationDiffList);

                    resultLines = compareEngine.DiffResult();

                    if (resultLines.Count > 0)
                    {
                        foreach (CompareResultSpan line in resultLines)
                        {
                            if (line.Status != CompareResultSpanStatus.NoChange)
                            {
                                lvFile1.SetItemDifferentDirectory(count - 1);
                                lvFile2.SetItemDifferentDirectory(count - 1);

                                summary.LinesDifferent++;
                                summary.LinesMatch--;

                                DifferenceLines.Add(count);
                                

                                break;
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void backgroundWorkerCompleteProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                lvFile1.RefreshItems();
                lvFile2.RefreshItems();

                DifferenceLines.Sort();

                lblDifferences.Text = "Diffences: " + DifferenceLines.Count;

                progressAddiditonal.Value = 100;
                progressAddiditonal.Visible = false;
                lblAdditionalComparison.Visible = false;

            }
            catch (Exception)
            {

            }

        }

        #region Private Methods

        private void LeftIgnoreLine()
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }

            if (lvFile1.SelectedItems != null)
            {
                int startingItemIndex = int.Parse(lvFile1.SelectedItems[0].SubItems[0].Text) - 1;
                int totalSelectedItems = lvFile1.SelectedItems.Count;

                for (int i = 0; i < totalSelectedItems; i++)
                {
                    lvFile2.IgnoreItem(startingItemIndex + i);
                    lvFile1.IgnoreItem(startingItemIndex + i);
                }

                lvFile1.RefreshItems();
                lvFile2.RefreshItems();
            }
        }

        private void RightIgnoreLine()
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }

            if (lvFile2.SelectedItems != null)
            {
                int startingItemIndex = int.Parse(lvFile2.SelectedItems[0].SubItems[0].Text) - 1;
                int totalSelectedItems = lvFile2.SelectedItems.Count;

                for (int i = 0; i < totalSelectedItems; i++)
                {
                    lvFile1.IgnoreItem(startingItemIndex + i);
                    lvFile2.IgnoreItem(startingItemIndex + i);
                }

                lvFile1.RefreshItems();
                lvFile2.RefreshItems();
            }
        }

        private void ComparePath()
        {
           

            if (ValidFile(txtFile1.Text) == false)
            {
                if (ValidDirectory(txtFile1.Text) == false)
                {
                    if (String.IsNullOrEmpty(txtFile1.Text) == false)
                    {
                        MessageBox.Show(txtFile1.Text + "\n\n is not a valid path", "Invalid Path", MessageBoxButtons.OK);
                    }
                    return;
                }
            }
            if (ValidFile(txtFile2.Text) == false)
            {
                if (ValidDirectory(txtFile2.Text) == false)
                {
                    if (String.IsNullOrEmpty(txtFile1.Text) == false)
                    {
                        MessageBox.Show(txtFile2.Text + "\n\n is not a valid path", "Invalid Path", MessageBoxButtons.OK);
                    }
                    return;
                }
            }

            if (ValidFile(txtFile1.Text))
            {
                if (ValidDirectory(txtFile2.Text))
                {
                    MessageBox.Show
                        ("Cannot Compare a file to a directory", "Invalid Comparison", MessageBoxButtons.OK);
                    return;
                }
            }
            if (ValidFile(txtFile2.Text))
            {
                if (ValidDirectory(txtFile1.Text))
                {
                    MessageBox.Show
                        ("Cannot Compare a file to a directory", "Invalid Comparison", MessageBoxButtons.OK);
                    return;
                }
            }

            StartTime = DateTime.Now;

            if (String.IsNullOrEmpty(txtFile1.Text) == false && String.IsNullOrEmpty(txtFile2.Text) == false)
            {
                var calculateDifference = new ComparisonProgress(txtFile1.Text, txtFile2.Text);
                calculateDifference.Show();
            }

            if (comparisonPathType == PathType.File)
            {
                CloseForm();
            }

            return;
        }

        private void CopyAllItemsRightToLeft()
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }

            string FileName1 = Path.GetFileName(txtFile1.Text);
            string FileName2 = Path.GetFileName(txtFile2.Text);

            if (MessageBox.Show("Copy all lines from:\n\n" + FileName2
                                + "\n\nTo:\n\n" + FileName1, "Copy and Replace all Lines?"
                                , MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            lvFile1.ClearItems();

            foreach (CompareItem item in lvFile2.AllItems)
            {
                if (item.ItemSourceTag != CompareItem.ItemSource.NotInOriginal)
                {
                    lvFile1.Add((CompareItem) item.Clone());
                }
            }


            DifferenceLines.Clear();
            PaintSummaryPanel();

            lvFile1.RefreshItems();
            lvFile2.RefreshItems();
        }

        private void CopyAllItemsLeftToRight()
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }

            string FileName1 = Path.GetFileName(txtFile1.Text);
            string FileName2 = Path.GetFileName(txtFile2.Text);

            if (MessageBox.Show("Copy all lines from:\n\n" + FileName1
                                + "\n\nTo:\n\n" + FileName2, "Copy and Replace all Lines?"
                                , MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            lvFile2.ClearItems();

            foreach (CompareItem item in lvFile1.AllItems)
            {
                if (item.ItemSourceTag != CompareItem.ItemSource.NotInOriginal)
                {
                    lvFile2.Add((CompareItem) item.Clone());
                }
            }


            DifferenceLines.Clear();
            PaintSummaryPanel();

            lvFile1.RefreshItems();
            lvFile2.RefreshItems();
        }

        private void EditItem()
        {
            Cursor = Cursors.WaitCursor;

            int ItemIndex = 0;

            if (lvFile1.SelectedItems == null && lvFile2.SelectedItems == null)
            {
                return;
            }

            if (lvFile1.SelectedItems.Count == 0 && lvFile2.SelectedItems.Count == 0)
            {
                return;
            }

            if (lvFile2.SelectedItems != null)
            {
                if (lvFile2.SelectedItems.Count > 0)
                {
                    ItemIndex = int.Parse(lvFile2.SelectedItems[0].SubItems[0].Text) - 1;
                }
            }

            if (lvFile1.SelectedItems != null)
            {
                if (lvFile1.SelectedItems.Count > 0)
                {
                    ItemIndex = int.Parse(lvFile1.SelectedItems[0].SubItems[0].Text) - 1;
                }
            }

            string line1 = "";
            string line2 = "";

            if (lvFile1.AllItems.Count > ItemIndex)
            {
                line1 = lvFile1.AllItems[ItemIndex].SubItems[1].Text;
            }

            if (lvFile2.AllItems.Count > ItemIndex)
            {
                line2 = lvFile2.AllItems[ItemIndex].SubItems[1].Text;
            }

            var editLine = new EditLine(line1, line2);

            if (editLine.ShowDialog() == DialogResult.OK)
            {
                lvFile1.EditItem(ItemIndex, editLine.Line1);
                lvFile2.EditItem(ItemIndex, editLine.Line2);

                if (editLine.Line2 == editLine.Line1)
                {
                    lvFile1.IgnoreItem(ItemIndex);
                    lvFile2.IgnoreItem(ItemIndex);
                    lvFile1.RefreshItems();
                    lvFile2.RefreshItems();
                }
                else
                {
                    lvFile1.SetItemDifferent(ItemIndex);
                    lvFile2.SetItemDifferent(ItemIndex);
                    lvFile1.RefreshItems();
                    lvFile2.RefreshItems();
                }
            }
            Cursor = Cursors.Default;
        }

        private void PaintSummaryPanel()
        {
            if (ListFiles1 != null)
            {
                summaryPanel.DifferenceLines = DifferenceLines;
                summaryPanel.TotalNumberLines = ListFiles1.Count;

                summaryPanel.ScreenStart = lvFile1.CurrentPageStartIndex;
                summaryPanel.ScreenEnd = lvFile1.CurrentPageEndIndex;

                summaryPanel.Refresh();
            }
        }

        private static bool ValidFile(string fileName)
        {
            if (fileName != string.Empty)
            {
                if (File.Exists(fileName))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ValidDirectory(string dirName)
        {
            if (dirName != string.Empty)
            {
                if (Directory.Exists(dirName))
                {
                    return true;
                }
            }
            return false;
        }

        private void CopyDirectory(string Src, string Dst)
        {
            CopyWindows++;
            var fileIOProgress = new FileIOProgress(Src, Dst, refreshAndCloseDelegate);
            fileIOProgress.Show();
        }

        #endregion

        #region Events

        private void FileComparisonResults_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //SetWindowTheme(toolStrip.Handle, "", "");
                //SetWindowTheme(lvFile1.Handle, "", "");
                //SetWindowTheme(lvFile2.Handle, "", "");
                //Invalidate();

                lvFile1.SuspendLayout();
                lvFile2.SuspendLayout();
                lvFile1.Visible = false;
                lvFile2.Visible = false;

                lvFile1.AddRange(ListFiles1);
                lvFile2.AddRange(ListFiles2);

                lvFile1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lvFile2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);


                lvFile1.Visible = true;
                lvFile2.Visible = true;

                lvFile1.ResumeLayout();
                lvFile2.ResumeLayout();


                EndTime = DateTime.Now;
                lblStatus.Text
                    = string.Format
                        ("Results: {0} secs.", EndTime.Subtract(StartTime).Seconds.ToString("#0.00"));

                lvFile1.RefreshItems();
                lvFile2.RefreshItems();

                lvFile1.Focus();

                if (txtFile1.Text.ToLower().EndsWith("doc"))
                {
                    mnuLeftSaveChanges.Enabled = false;
                    mnuRightSaveChanges.Enabled = false;

                    mnuLeftSaveChangesAs.Enabled = false;
                    mnuRightSaveChangesAs.Enabled = false;
                }

                if (DifferenceLines != null)
                {
                    lblDifferences.Text = "Diffences: " + DifferenceLines.Count;

                    if (DifferenceLines.Count == 0)
                    {
                        if (comparisonPathType == PathType.File)
                        {
                            MessageBox.Show("Files are Identical", "Code Compare", MessageBoxButtons.OK);
                        }
                        //else
                        //{
                        //    MessageBox.Show
                        //        ("Directories are Identical", "Code Compare", MessageBoxButtons.OK);
                        //}
                    }
                }
                else
                {
                    lblDifferences.Text = "Diffences: " + 0;
                }

                if (comparisonPathType != PathType.File)
                {
                    FinishComparison();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Loading Results", MessageBoxButtons.OK);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            PaintSummaryPanel();
        }

        private void summaryPanel_SummaryPanelMouseDown(object sender, EventArgs e)
        {
            lvFile1.SelectItem(summaryPanel.ClickedLine);
            lvFile2.SelectItem(summaryPanel.ClickedLine);

            PaintSummaryPanel();
        }

        private void ComparisonResults_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            } 
            
            if (lvFile2.ItemsChanged && !txtFile1.Text.ToLower().EndsWith("doc"))
            {
                if (MessageBox.Show
                        ("Do you wish to Save Changes before Closing?", "Save Changes", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                {
                    lvFile2.SaveItems(txtFile2.Text);
                }
            }

            if (Application.OpenForms.Count < 2)
            {
                Application.Exit();
            }
        }

        #endregion

        #region ListView

        private void lvFile1_Scroll(object sender, EventArgs e)
        {
            lvFile2.SelectItem(lvFile1.CurrentPageStartIndex);

            PaintSummaryPanel();
        }

        private void lvFile2_Scroll(object sender, EventArgs e)
        {
            lvFile1.SelectItem(lvFile2.CurrentPageStartIndex);
            PaintSummaryPanel();
        }

        private void lvFile1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPath1 = string.Empty;
            lblSelectedPath1.Text = string.Empty;

            if (comparisonPathType == PathType.Directory)
            {
                if (lvFile1.SelectedItems.Count > 0)
                {
                    if (lvFile1.AllItems[lvFile1.SelectedItems[0].Index].SubItems.Count > 2)
                    {
                        int a = int.Parse(lvFile1.SelectedItems[0].SubItems[0].Text) - 1;
                        SelectedPath1 = lvFile1.AllItems[a].SubItems[1].Text;

                        lblSelectedPath1.Text = "Selected Path Left: " + SelectedPath1;
                        txtFile1.Text = FilePath1 + "\\" + SelectedPath1;
                    }
                }
            }
        }

        private void lvFile2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPath2 = string.Empty;
            lblSelectedPath2.Text = string.Empty;

            if (comparisonPathType == PathType.Directory)
            {
                if (lvFile2.SelectedItems.Count > 0)
                {
                    if (lvFile2.AllItems[lvFile2.SelectedItems[0].Index].SubItems.Count > 2)
                    {
                        int a = int.Parse(lvFile2.SelectedItems[0].SubItems[0].Text) - 1;
                        SelectedPath2 = lvFile2.AllItems[a].SubItems[1].Text;
                        lblSelectedPath2.Text = "Selected Path Right: " + SelectedPath2;
                        txtFile2.Text = FilePath2 + "\\" + SelectedPath2;
                    }
                }
            }
        }

        private void lvFile1_ListViewDoubleClick(object sender, EventArgs e)
        {
            if (comparisonPathType == PathType.Directory)
            {
                string fullPath1 = string.Empty;
                string fullPath2 = string.Empty;

                if (String.IsNullOrEmpty(SelectedPath1) == false && String.IsNullOrEmpty(SelectedPath2) == false)
                {
                    fullPath1 = FilePath1 + "\\" + SelectedPath1;
                    fullPath2 = FilePath2 + "\\" + SelectedPath2;
                }
                else if (String.IsNullOrEmpty(SelectedPath1) == false && String.IsNullOrEmpty(SelectedPath2))
                {
                    fullPath1 = FilePath1 + "\\" + SelectedPath1;
                    fullPath2 = FilePath2 + "\\" + SelectedPath1;
                }
                else if (String.IsNullOrEmpty(SelectedPath1) && String.IsNullOrEmpty(SelectedPath2) == false)
                {
                    fullPath1 = FilePath1 + "\\" + SelectedPath2;
                    fullPath2 = FilePath2 + "\\" + SelectedPath2;
                }

                if (String.IsNullOrEmpty(fullPath1) == false && String.IsNullOrEmpty(fullPath2) == false)
                {
                    var calculateDifference = new ComparisonProgress(fullPath1, fullPath2);
                    calculateDifference.Show();
                }
            }
            else if (comparisonPathType == PathType.File)
            {
                EditItem();
            }
        }

        private void lvFile2_ListViewDoubleClick(object sender, EventArgs e)
        {
            if (comparisonPathType == PathType.Directory)
            {
                string fullPath1 = string.Empty;
                string fullPath2 = string.Empty;

                if (String.IsNullOrEmpty(SelectedPath1) == false && String.IsNullOrEmpty(SelectedPath2) == false)
                {
                    fullPath1 = FilePath1 + "\\" + SelectedPath1;
                    fullPath2 = FilePath2 + "\\" + SelectedPath2;
                }
                else if (String.IsNullOrEmpty(SelectedPath1) == false && String.IsNullOrEmpty(SelectedPath2))
                {
                    fullPath1 = FilePath1 + "\\" + SelectedPath1;
                    fullPath2 = FilePath2 + "\\" + SelectedPath1;
                }
                else if (String.IsNullOrEmpty(SelectedPath1) && String.IsNullOrEmpty(SelectedPath2) == false)
                {
                    fullPath1 = FilePath1 + "\\" + SelectedPath2;
                    fullPath2 = FilePath2 + "\\" + SelectedPath2;
                }

                if (String.IsNullOrEmpty(fullPath1) == false && String.IsNullOrEmpty(fullPath2) == false)
                {
                    var calculateDifference =
                        new ComparisonProgress(fullPath1, fullPath2);
                    calculateDifference.Show();
                }
            }
            else if (comparisonPathType == PathType.File)
            {
                EditItem();
            }
        }

        private void lvFile1_ListViewDragDrop(object sender, DragEventArgs e, string fileName)
        {
            txtFile1.Text = fileName;
            ComparePath();
        }

        private void lvFile2_ListViewDragDrop(object sender, DragEventArgs e, string fileName)
        {
            txtFile2.Text = fileName;
            ComparePath();
        }

        #endregion

        #region Menus

        private void mnuRightSaveChangesAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = txtFile2.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(saveFileDialog.FileName) == false)
                {
                    lvFile2.SaveItems(saveFileDialog.FileName);
                    txtFile2.Text = saveFileDialog.FileName;

                    lvFile2.SaveItems(saveFileDialog.FileName);
                }
            }
        }

        private void mnuLeftSaveChangesAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = txtFile1.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(saveFileDialog.FileName) == false)
                {
                    lvFile1.SaveItems(saveFileDialog.FileName);
                    txtFile1.Text = saveFileDialog.FileName;

                    lvFile1.SaveItems(saveFileDialog.FileName);
                }
            }
        }

        private void mnuRightSaveChanges_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to overwrite existing file " + txtFile2.Text
                                , "Save File?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lvFile2.SaveItems(txtFile2.Text);
            }
        }

        private void mnuLeftSaveChanges_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to overwrite existing file " + txtFile1.Text
                                , "Save File?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lvFile2.SaveItems(txtFile1.Text);
            }
        }

        private void mnuRightCopyAllToOtherSide_Click(object sender, EventArgs e)
        {
            CopyAllItemsRightToLeft();
        }

        private void mnuLeftCopyToOtherSide_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }


            if (lvFile1.SelectedItems != null)
            {
                if (lvFile1.SelectAll)
                {
                    CopyAllItemsLeftToRight();
                }
                else
                {
                    foreach (ListViewItem selectedItem in lvFile1.SelectedItems)
                    {
                        int x = int.Parse(selectedItem.SubItems[0].Text) - 1;

                        lvFile2.EditItem(x, lvFile1.AllItems[x]);
                        lvFile1.ModifiedItem(x);

                        for (int i = 0; i < DifferenceLines.Count; i++)
                        {
                            if ((int) DifferenceLines[i] == x)
                            {
                                DifferenceLines.RemoveAt(i);
                            }
                        }
                    }
                }
            }

            PaintSummaryPanel();
            lvFile2.RefreshItems();
        }

        private void mnuRightCopyToOtherSide_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            } 
            
            if (lvFile2.SelectedItems != null)
            {
                if (lvFile2.SelectAll)
                {
                    CopyAllItemsRightToLeft();
                }
                else
                {
                    foreach (ListViewItem selectedItem in lvFile2.SelectedItems)
                    {
                        int x = int.Parse(selectedItem.SubItems[0].Text) - 1;

                        lvFile1.EditItem(x, lvFile2.AllItems[x]);
                        lvFile2.ModifiedItem(x);

                        for (int i = 0; i < DifferenceLines.Count; i++)
                        {
                            if ((int) DifferenceLines[i] == x)
                            {
                                DifferenceLines.RemoveAt(i);
                            }
                        }
                    }
                }
            }

            PaintSummaryPanel();
            lvFile1.RefreshItems();
        }

        private void mnuRightInsertLine_Click(object sender, EventArgs e)
        {
            int ItemIndex = int.Parse(lvFile2.SelectedItems[0].SubItems[0].Text) - 1;

            if (lvFile2.AllItems[ItemIndex] == null)
            {
                return;
            }

            var item = (CompareItem) lvFile2.AllItems[ItemIndex].Clone();

            item.BackColor = Color.White;
            item.SubItems[1].Text = "";

            lvFile2.Insert(ItemIndex, item);

            lvFile2.RefreshItems();
            PaintSummaryPanel();
        }

        private void mnuLeftInsertLine_Click(object sender, EventArgs e)
        {
            int ItemIndex = int.Parse(lvFile1.SelectedItems[0].SubItems[0].Text) - 1;

            if (lvFile1.AllItems[ItemIndex] == null)
            {
                return;
            }

            var item = (CompareItem) lvFile1.AllItems[ItemIndex].Clone();

            item.BackColor = Color.White;
            item.SubItems[1].Text = "";

            lvFile1.Insert(ItemIndex, item);

            lvFile1.RefreshItems();
            PaintSummaryPanel();
        }

        private void mnuRightIOIgnore_Click(object sender, EventArgs e)
        {
            RightIgnoreLine();
        }

        private void mnuLeftIOIgnore_Click(object sender, EventArgs e)
        {
            LeftIgnoreLine();
        }

        private void mnuRightIgnoreLine_Click(object sender, EventArgs e)
        {
            RightIgnoreLine();
        }

        private void mnuLeftIgnoreLines_Click(object sender, EventArgs e)
        {
            LeftIgnoreLine();
        }

        private void mnuRightEditLines_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void mnuLeftEditLines_Click(object sender, EventArgs e)
        {
            EditItem();
        }

        private void mnuLeftDelete_Click(object sender, EventArgs e)
        {
            

            if (MessageBox.Show
                    ("Delete Selected Line(s) From:\n\n" + Path.GetFileName(txtFile1.Text)
                     , "Delete Selected Line(s)?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            int x = 0;

            foreach (ListViewItem item in lvFile1.SelectedItems)
            {
                int ItemIndex = int.Parse(item.SubItems[0].Text) - 1;

                lvFile1.DeleteItem(ItemIndex - x);
                lvFile2.DeleteItemIfNotInOriginal(ItemIndex - x);

                x++;
            }
            lvFile1.ReCalculateIndex();
            lvFile2.ReCalculateIndex();

            lvFile1.RefreshItems();
            lvFile2.RefreshItems();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
        }

        private void mnuRightIODelete_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            } 
            
            txtFile1.Text = FilePath1;
            txtFile2.Text = FilePath2;

            foreach (ListViewItem item in lvFile2.SelectedItems)
            {
                if (item.SubItems.Count < 5)
                {
                    return;
                }

                if (item.SubItems[4] == null)
                {
                    return;
                }
                if (item.SubItems[1] == null)
                {
                    return;
                }
                if (String.IsNullOrEmpty(item.SubItems[4].Text))
                {
                    return;
                }
                if (String.IsNullOrEmpty(item.SubItems[1].Text))
                {
                    return;
                }

                string path = item.SubItems[4].Text + @"\" + item.SubItems[1].Text;

                if (ValidFile(path))
                {
                    if (MessageBox.Show("Delete File: " + path, "Delete File", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            File.Delete(path);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Cannot Delete File", MessageBoxButtons.OK);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    path = item.SubItems[4].Text;

                    if (ValidDirectory(path))
                    {
                        if (MessageBox.Show("Delete Directory: " + path, "Delete Directory", MessageBoxButtons.YesNo) ==
                            DialogResult.Yes)
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                Directory.Delete(path, true);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Cannot Delete Directory", MessageBoxButtons.OK);
                            }
                            finally
                            {
                                Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            ComparePath();
            CloseForm();
        }

        private void mnuLeftIODelete_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            } 
            
            txtFile1.Text = FilePath1;
            txtFile2.Text = FilePath2;

            foreach (ListViewItem item in lvFile1.SelectedItems)
            {
                if (item.SubItems.Count < 5)
                {
                    return;
                }

                if (item.SubItems[4] == null)
                {
                    return;
                }
                if (item.SubItems[1] == null)
                {
                    return;
                }
                if (String.IsNullOrEmpty(item.SubItems[4].Text))
                {
                    return;
                }
                if (String.IsNullOrEmpty(item.SubItems[1].Text))
                {
                    return;
                }

                string path = item.SubItems[4].Text + @"\" + item.SubItems[1].Text;

                if (ValidFile(path))
                {
                    if (MessageBox.Show("Delete File: " + path, "Delete File", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            File.Delete(path);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Cannot Delete File", MessageBoxButtons.OK);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    path = item.SubItems[4].Text;

                    if (ValidDirectory(path))
                    {
                        if (MessageBox.Show("Delete Directory: " + path, "Delete Directory", MessageBoxButtons.YesNo) ==
                            DialogResult.Yes)
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                Directory.Delete(path, true);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Cannot Delete Directory", MessageBoxButtons.OK);
                            }
                            finally
                            {
                                Cursor = Cursors.Default;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }


            ComparePath();
            CloseForm();
        }

        private void mnuLeftIOCopyPath_Click(object sender, EventArgs e)
        {
            IOCopySelectedFilesFromLefttoRight(false);
            return;
        }

        private void IOCopyAllFilesFromLefttoRight()
        {
            Cursor = Cursors.WaitCursor;

            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }

            foreach (ListViewItem item in lvFile1.AllItems)
            {
                if (item.SubItems.Count < 5)
                {
                    Cursor = Cursors.Default;
                    continue;
                }
                string sourceFilePath;
                string destinationFilePath;

                if (item.SubItems[3].Text == "File")
                {
                    sourceFilePath = item.SubItems[4].Text + @"\" + item.SubItems[1].Text;
                    destinationFilePath = FilePath2 + @"\" + item.SubItems[1].Text;
                }
                else
                {
                    sourceFilePath = item.SubItems[4].Text;
                    destinationFilePath = FilePath2 + @"\" + item.SubItems[1].Text;
                }

                if (ValidFile(sourceFilePath))
                {
                    if (!File.Exists(destinationFilePath))
                    {
                        File.Copy(sourceFilePath, destinationFilePath);
                    }

                    Cursor = Cursors.Default;


                    txtFile1.Text = FilePath1;
                    txtFile2.Text = FilePath2;
                }
                else if (ValidDirectory(sourceFilePath))
                {
                    if (!Directory.Exists(destinationFilePath))
                    {
                        CopyDirectory(sourceFilePath, destinationFilePath);
                        Thread.Sleep(50);
                    }
                }
            }
            Cursor = Cursors.Default;

            if (CopyWindows <= 0)
                RefreshAndClose();
        }


        private void IOCopySelectedFilesFromLefttoRight(bool quiet)
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }
            
            bool MultiPath = false;
            bool AllowRefresh = true;

            if (lvFile1.SelectedItems.Count > 1)
            {
                if (!quiet)
                {
                    if (
                        MessageBox.Show("Copy Selected File(s) and Folder(s)", "Copy Selected", MessageBoxButtons.YesNo) ==
                        DialogResult.Yes)
                    {
                        MultiPath = true;
                        Cursor = Cursors.WaitCursor;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    AllowRefresh = false;
                    MultiPath = true;
                    Cursor = Cursors.WaitCursor;
                }
            }

            foreach (ListViewItem item in lvFile1.SelectedItems)
            {
                if (item.SubItems.Count < 5)
                {
                    Cursor = Cursors.Default;
                    continue;
                }
                string sourceFilePath;
                string destinationFilePath;

                if (item.SubItems[3].Text == "File")
                {
                    sourceFilePath = item.SubItems[4].Text + @"\" + item.SubItems[1].Text;
                    destinationFilePath = FilePath2 + @"\" + item.SubItems[1].Text;
                }
                else
                {
                    sourceFilePath = item.SubItems[4].Text;
                    destinationFilePath = FilePath2 + @"\" + item.SubItems[1].Text;
                }

                if (ValidFile(sourceFilePath))
                {
                    if (File.Exists(destinationFilePath))
                    {
                        MessageBox.Show(destinationFilePath + " Already Exists", "File Already Exists",
                                        MessageBoxButtons.OK);

                        Cursor = Cursors.Default;
                        return;
                    }

                    if (MultiPath == false)
                    {
                        if (
                            MessageBox.Show("Copy File: \n\n" + sourceFilePath + "\n\n To: \n\n" + destinationFilePath,
                                            "Copy File", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            File.Copy(sourceFilePath, destinationFilePath);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                    else
                    {
                        File.Copy(sourceFilePath, destinationFilePath);
                    }

                    Cursor = Cursors.Default;


                    txtFile1.Text = FilePath1;
                    txtFile2.Text = FilePath2;
                }
                else if (ValidDirectory(sourceFilePath))
                {
                    if (Directory.Exists(destinationFilePath))
                    {
                        MessageBox.Show(destinationFilePath + " Already Exists", "Directory Already Exists",
                                        MessageBoxButtons.OK);
                        Cursor = Cursors.Default;
                        return;
                    }

                    if (MultiPath == false)
                    {
                        if (
                            MessageBox.Show(
                                "Copy Directory: \n\n" + sourceFilePath + "\n\n To: \n\n" + destinationFilePath,
                                "Copy Directory", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CopyDirectory(sourceFilePath, destinationFilePath);
                            AllowRefresh = false;
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                    else
                    {
                        CopyDirectory(sourceFilePath, destinationFilePath);
                        AllowRefresh = false;
                    }
                }
            }
            Cursor = Cursors.Default;


            if (!quiet)
            {
                txtFile1.Text = FilePath1;
                txtFile2.Text = FilePath2;
            }
            if (AllowRefresh)
            {
                RefreshAndClose();
            }
        }

        private void mnuRightIOCopyPath_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            } 
            bool MultiPath = false;
            bool AllowRefresh = true;


            if (lvFile2.SelectedItems.Count > 1)
            {
                if (MessageBox.Show("Copy Selected File(s) and Folder(s)", "Copy Selected", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    MultiPath = true;
                }
                else
                {
                    return;
                }
            }

            if (MultiPath)
            {
                Cursor = Cursors.WaitCursor;
            }

            foreach (ListViewItem item in lvFile2.SelectedItems)
            {
                if (item.SubItems.Count < 5)
                {
                    Cursor = Cursors.Default;
                    return;
                }
                string sourceFilePath;
                string destinationFilePath;

                if (item.SubItems[3].Text == "File")
                {
                    sourceFilePath = item.SubItems[4].Text + @"\" + item.SubItems[1].Text;
                    destinationFilePath = FilePath1 + @"\" + item.SubItems[1].Text;
                }
                else
                {
                    sourceFilePath = item.SubItems[4].Text;
                    destinationFilePath = FilePath1 + @"\" + item.SubItems[1].Text;
                }


                if (ValidFile(sourceFilePath))
                {
                    if (File.Exists(destinationFilePath))
                    {
                        MessageBox.Show(destinationFilePath + " Already Exists", "File Already Exists",
                                        MessageBoxButtons.OK);
                        Cursor = Cursors.Default;
                        return;
                    }


                    if (MultiPath == false)
                    {
                        if (
                            MessageBox.Show("Copy File: \n\n" + sourceFilePath + "\n\n To: \n\n" + destinationFilePath,
                                            "Copy File", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            File.Copy(sourceFilePath, destinationFilePath);
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                    else
                    {
                        File.Copy(sourceFilePath, destinationFilePath);
                    }
                    Cursor = Cursors.Default;
                    txtFile1.Text = FilePath1;
                    txtFile2.Text = FilePath2;
                }
                else if (ValidDirectory(sourceFilePath))
                {
                    if (Directory.Exists(destinationFilePath))
                    {
                        MessageBox.Show(destinationFilePath + " Already Exists", "Directory Already Exists",
                                        MessageBoxButtons.OK);
                        Cursor = Cursors.Default;
                        return;
                    }

                    if (MultiPath == false)
                    {
                        if (
                            MessageBox.Show(
                                "Copy Directory: \n\n" + sourceFilePath + "\n\n To: \n\n" + destinationFilePath,
                                "Copy Directory", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            CopyDirectory(sourceFilePath, destinationFilePath);
                            AllowRefresh = false;
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            return;
                        }
                    }
                    else
                    {
                        CopyDirectory(sourceFilePath, destinationFilePath);
                        AllowRefresh = false;
                    }
                }
            }
            Cursor = Cursors.Default;

            txtFile1.Text = FilePath1;
            txtFile2.Text = FilePath2;

            if (AllowRefresh)
            {
                RefreshAndClose();
            }
            return;
        }

        private void mnuLeftSelectAll_Click(object sender, EventArgs e)
        {
            lvFile1.SelectAllItems();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            lvFile2.SelectAllItems();
        }

        private void mnuSummary_Click(object sender, EventArgs e)
        {
            var comparisonSummary = new ComparisonSummary(summary);
            comparisonSummary.ShowDialog();
        }

        #endregion

        #region Buttons

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (DifferenceLines != null)
            {
                if (DifferenceLines.Count > 0)
                {
                    int line;

                    if ((int) DifferenceLines[currentDifferenceLine] > 0)
                    {
                        line = (int) DifferenceLines[currentDifferenceLine] - 1;
                    }
                    else
                    {
                        line = 0;
                    }

                    lvFile1.SelectItem(line);
                    lvFile2.SelectItem(line);

                    lblCurrentDifference.Text = "Currently Displayed: " + currentDifferenceLine + " Line:" +
                                                DifferenceLines[currentDifferenceLine];

                    currentDifferenceLine++;

                    if (currentDifferenceLine >= DifferenceLines.Count)
                    {
                        currentDifferenceLine = 0;
                    }
                    PaintSummaryPanel();

                   
                }
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (DifferenceLines != null)
            {
                if (DifferenceLines.Count > 0)
                {
                    if (currentDifferenceLine > 0)
                    {
                        currentDifferenceLine--;
                    }
                    lblCurrentDifference.Text = "Currently Displayed: " + currentDifferenceLine + " Line:" +
                                                DifferenceLines[currentDifferenceLine];

                    int line;

                    if ((int) DifferenceLines[currentDifferenceLine] > 0)
                    {
                        line = (int) DifferenceLines[currentDifferenceLine] - 1;
                    }
                    else
                    {
                        line = 0;
                    }

                    lvFile1.SelectItem(line);
                    lvFile2.SelectItem(line);

                    PaintSummaryPanel();
                }
            }
        }

        private void btnCopyAllToOtherSide_Click(object sender, EventArgs e)
        {
            CopyAllItemsLeftToRight();
        }

        private void btnRefreshFromFile_Click(object sender, EventArgs e)
        {
            ComparePath();
            CloseForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (comparisonPathType == PathType.Directory)
            {
                txtFile1.Text = FilePath1;
                txtFile2.Text = FilePath2;
                ComparePath();
                CloseForm();
            }
            else
            {
                lvFile1.ItemsChanged = false;
                lvFile2.ItemsChanged = false;

                StartTime = DateTime.Now;

                if (String.IsNullOrEmpty(txtFile1.Text) == false && String.IsNullOrEmpty(txtFile2.Text) == false)
                {
                    var calculateDifference = new ComparisonProgress(lvFile1.AllItems, lvFile2.AllItems, txtFile1.Text, txtFile2.Text);
                    calculateDifference.Show();
                }

                if (comparisonPathType == PathType.File)
                {
                    CloseForm();
                }
            }
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            ComparePath();
        }

        private void btnDeleteLines_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show
                    ("Delete Selected Line(s) From:\n\n" + Path.GetFileName(txtFile2.Text),
                     "Delete Selected Line(s)?", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            int x = 0;

            foreach (ListViewItem item in lvFile2.SelectedItems)
            {
                int ItemIndex = int.Parse(item.SubItems[0].Text) - 1;

                lvFile1.DeleteItemIfNotInOriginal(ItemIndex - x);
                lvFile2.DeleteItem(ItemIndex - x);
                x++;
            }
            lvFile1.ReCalculateIndex();
            lvFile2.ReCalculateIndex();

            lvFile1.RefreshItems();
            lvFile2.RefreshItems();
        }

        private void btnDifferences_Click(object sender, EventArgs e)
        {
            btnDifferences.Checked = true;
            btnAll.Checked = false;

            lvFile1.DisplayDifferences();
            lvFile2.DisplayDifferences();
        }

        private void btnAllTool_Click(object sender, EventArgs e)
        {
            btnDifferences.Checked = false;
            btnAll.Checked = true;

            lvFile1.DisplayAll();
            lvFile2.DisplayAll();
        }

        private void CloseForm()
        {
            if (backgroundWorkerCompleteProcess.IsBusy)
            {
                backgroundWorkerCompleteProcess.CancelAsync();
            }

            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void btnStartNewComparison_Click(object sender, EventArgs e)
        {
            var comparisonType = new ComparisonType();
            comparisonType.Show();
            CloseForm();
        }

        private void btnAbout_ButtonClick(object sender, EventArgs e)
        {
            var about = new About();
            about.Show();
        }

        #endregion

        private void backgroundWorkerCompleteProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressAddiditonal.Maximum = 100;

                progressAddiditonal.Value = e.ProgressPercentage;
            }
            catch (Exception)
            {
                
            }

           
        }
    }
}