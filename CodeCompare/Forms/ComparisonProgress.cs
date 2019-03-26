using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CodeCompare.Shared;
using CompareEngine;
using FastListView;


namespace CodeCompare.Forms
{
    public partial class ComparisonProgress : BaseForm
    {
        private const int HowDeepToScan = 5;


        private readonly string Line1 = string.Empty;
        private readonly string Line2 = string.Empty;
    
        private readonly Summary summary;
        private PathType ComparisonPathType;

        private ArrayList DifferenceLines;

        private List<CompareItem> ListFiles1;
        private List<CompareItem> ListFiles2;
        private CompareText destinationDiffList;
        private ArrayList resultLines;
        private CompareText sourceDiffList;
        private DateTime startTime;



        #region Constructors

        public ComparisonProgress()
        {
            InitializeComponent();
            summary = new Summary();
        }

        public ComparisonProgress
            (
            List<CompareItem> listViewItems1,
            List<CompareItem> listViewItems2,
            string sourceFile,
            string destinationFile
            
            )
            : this()
        {
          

            var fileInfo = new FileCompareInfo();

            fileInfo.ComparePathType = PathType.ListItems;

            ComparisonPathType = fileInfo.ComparePathType;

            fileInfo.ListViewItems1 = listViewItems1;
            fileInfo.ListViewItems2 = listViewItems2;

            sourceDiffList = null;
            destinationDiffList = null;

            txtPath1.Text = sourceFile;
            txtPath2.Text = destinationFile;

            backgroundWorkerDifference.RunWorkerAsync(fileInfo);
        }


        public ComparisonProgress(string sourceFile, string destinationFile)
            : this()
        {
            var fileInfo = new FileCompareInfo();

            if (!ValidFile(sourceFile) && !ValidFile(destinationFile))
            {
                fileInfo.ComparePathType = PathType.Directory;
            }
            else
            {
                if (ValidFile(sourceFile) || ValidFile(destinationFile))
                {
                    fileInfo.ComparePathType = PathType.File;
                }
            }

            ComparisonPathType = fileInfo.ComparePathType;

            fileInfo.SourceFile = sourceFile;
            fileInfo.DestinationFile = destinationFile;

            sourceDiffList = null;
            destinationDiffList = null;

            txtPath1.Text = sourceFile;
            txtPath2.Text = destinationFile;

            backgroundWorkerDifference.RunWorkerAsync(fileInfo);
        }

       

        #endregion

        #region Members

        public List<CompareItem> ResultListFiles1
        {
            get { return ListFiles1; }
        }

        public List<CompareItem> ResultListFiles2
        {
            get { return ListFiles2; }
        }

        #endregion

        #region Public Methods

        public void DistplayFileResults(CompareText SourceDiffList, CompareText DestinationDiffList,
                                        ArrayList ResultLines)
        {
            CompareItem lviS;
            CompareItem lviD;

            ListFiles1 = new List<CompareItem>();
            ListFiles2 = new List<CompareItem>();

            sourceDiffList = SourceDiffList;
            destinationDiffList = DestinationDiffList;
            resultLines = ResultLines;


            int cnt = 1;
            DifferenceLines = new ArrayList();


            string numberMask = "00000";

            if (sourceDiffList.Count() > 99999 && sourceDiffList.Count() > sourceDiffList.Count())
            {
                for (int x = 0; x < sourceDiffList.Count().ToString().Length; x++)
                {
                    numberMask = numberMask + "0";
                }
            }
            else if (destinationDiffList.Count() > 99999)
            {
                for (int x = 0; x < destinationDiffList.Count().ToString().Length; x++)
                {
                    numberMask = numberMask + "0";
                }
            }

            foreach (CompareResultSpan drs in resultLines)
            {
                switch (drs.Status)
                {
                    case CompareResultSpanStatus.DeleteSource:
                        for (int i = 0; i < drs.Length; i++)
                        {
                            lviS = new CompareItem(cnt.ToString(numberMask));
                            lviD = new CompareItem(cnt.ToString(numberMask));

                            DifferenceLines.Add(cnt);

                            lviS.CompareResultTag = CompareItem.CompareResult.Add;
                            lviD.CompareResultTag = CompareItem.CompareResult.Add;
                            lviS.ItemSourceTag = CompareItem.ItemSource.Original;
                            lviD.ItemSourceTag = CompareItem.ItemSource.NotInOriginal;

                            summary.LinesLeftOnly++;

                            //Green
                            lviS.BackColor = Color.FromArgb(208, 236, 204);
                            lviD.BackColor = Color.FromArgb(208, 236, 204);

                            lviS.SubItems.Add
                                ((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Line);

                            lviD.SubItems.Add("");

                            ListFiles1.Add(lviS);
                            ListFiles2.Add(lviD);


                            cnt++;

                            if (DifferenceLines.Count < 20)
                            {
                                backgroundWorkerDifference.ReportProgress(40 + DifferenceLines.Count);
                            }
                        }

                        break;
                    case CompareResultSpanStatus.NoChange:
                        for (int i = 0; i < drs.Length; i++)
                        {
                            lviS = new CompareItem(cnt.ToString(numberMask));
                            lviD = new CompareItem(cnt.ToString(numberMask));

                            lviS.CompareResultTag = CompareItem.CompareResult.Equal;
                            lviD.CompareResultTag = CompareItem.CompareResult.Equal;
                            lviS.ItemSourceTag = CompareItem.ItemSource.Original;
                            lviD.ItemSourceTag = CompareItem.ItemSource.Original;

                            summary.LinesMatch++;

                            lviS.BackColor = Color.White;
                            lviD.BackColor = Color.White;

                            lviS.SubItems.Add
                                ((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Line);

                            lviD.SubItems.Add
                                ((destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Line);


                            ListFiles1.Add(lviS);
                            ListFiles2.Add(lviD);

                            if (DifferenceLines.Count < 20)
                            {
                                backgroundWorkerDifference.ReportProgress(40 + DifferenceLines.Count);
                            }
                            cnt++;
                        }

                        break;
                    case CompareResultSpanStatus.AddDestination:
                        for (int i = 0; i < drs.Length; i++)
                        {
                            lviS = new CompareItem(cnt.ToString(numberMask));
                            lviD = new CompareItem(cnt.ToString(numberMask));

                            lviS.CompareResultTag = CompareItem.CompareResult.Delete;
                            lviD.CompareResultTag = CompareItem.CompareResult.Delete;
                            lviS.ItemSourceTag = CompareItem.ItemSource.NotInOriginal;
                            lviD.ItemSourceTag = CompareItem.ItemSource.Original;

                            summary.LinesRightOnly++;

                            DifferenceLines.Add(cnt);

                            //Gray
                            lviS.BackColor = Color.FromArgb(224, 224, 224);

                            //LightCoral
                            lviD.BackColor = Color.FromArgb(241, 213, 214);

                            lviS.SubItems.Add("");
                            lviD.SubItems.Add
                                ((destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Line);

                            ListFiles1.Add(lviS);
                            ListFiles2.Add(lviD);

                            if (DifferenceLines.Count < 20)
                            {
                                backgroundWorkerDifference.ReportProgress(40 + DifferenceLines.Count);
                            }
                            cnt++;
                        }

                        break;
                    case CompareResultSpanStatus.Replace:
                        for (int i = 0; i < drs.Length; i++)
                        {
                            lviS = new CompareItem(cnt.ToString(numberMask));
                            lviD = new CompareItem(cnt.ToString(numberMask));

                            lviS.CompareResultTag = CompareItem.CompareResult.Replace;
                            lviD.CompareResultTag = CompareItem.CompareResult.Replace;
                            lviS.ItemSourceTag = CompareItem.ItemSource.Original;
                            lviD.ItemSourceTag = CompareItem.ItemSource.Original;

                            summary.LinesDifferent++;

                            DifferenceLines.Add(cnt);

                            //Green
                            lviS.BackColor = Color.FromArgb(208, 236, 204);
                            lviD.BackColor = Color.FromArgb(208, 236, 204);

                            lviS.SubItems.Add
                                ((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Line);
                            lviD.SubItems.Add
                                ((destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Line);

                            ListFiles1.Add(lviS);
                            ListFiles2.Add(lviD);

                            if (DifferenceLines.Count < 20)
                            {
                                backgroundWorkerDifference.ReportProgress(40 + DifferenceLines.Count);
                            }
                            cnt++;
                        }

                        break;
                }
            }
        }

        public void DisplayDirectoryResults(CompareText SourceDiffList, CompareText DestinationDiffList,
                                            ArrayList ResultLines)
        {
            CompareItem lviS;
            CompareItem lviD;

            ListFiles1 = new List<CompareItem>();
            ListFiles2 = new List<CompareItem>();

            sourceDiffList = SourceDiffList;
            destinationDiffList = DestinationDiffList;
            resultLines = ResultLines;

            int cnt = 1;
            DifferenceLines = new ArrayList();

            string numberMask = "000";

            if (sourceDiffList.Count() > 999 && sourceDiffList.Count() > sourceDiffList.Count())
            {
                for (int x = 0; x < sourceDiffList.Count().ToString().Length; x++)
                {
                    numberMask = numberMask + "0";
                }
            }
            else if (destinationDiffList.Count() > 999)
            {
                for (int x = 0; x < destinationDiffList.Count().ToString().Length; x++)
                {
                    numberMask = numberMask + "0";
                }
            }


            foreach (CompareResultSpan drs in resultLines)
            {
                switch (drs.Status)
                {
                    case CompareResultSpanStatus.DeleteSource:
                        for (int i = 0; i < drs.Length; i++)
                        {
                            lviS = new CompareItem(cnt.ToString(numberMask));
                            lviD = new CompareItem(cnt.ToString(numberMask));

                            DifferenceLines.Add(cnt);

                            lviS.CompareResultTag = CompareItem.CompareResult.Add;
                            lviD.CompareResultTag = CompareItem.CompareResult.Add;
                            lviS.ItemSourceTag = CompareItem.ItemSource.Original;
                            lviD.ItemSourceTag = CompareItem.ItemSource.NotInOriginal;

                            summary.LinesLeftOnly++;

                            //Green
                            lviS.BackColor = Color.FromArgb(208, 236, 204);
                            lviD.BackColor = Color.FromArgb(208, 236, 204);

                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Line);
                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Size);
                            lviS.SubItems.Add(
                                (sourceDiffList.GetByIndex(drs.SourceIndex + i)).Type.ToString());
                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Path);

                            if ((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Type == PathType.Directory)
                            {
                                lviS.ImageIndex = 0;
                            }
                            else
                            {
                                lviS.ImageIndex = 1;
                            }

                            lviD.SubItems.Add("");

                            ListFiles1.Add(lviS);
                            ListFiles2.Add(lviD);
                            cnt++;
                        }

                        break;
                    case CompareResultSpanStatus.NoChange:
                        for (int i = 0; i < drs.Length; i++)
                        {
                            lviS = new CompareItem(cnt.ToString(numberMask));
                            lviD = new CompareItem(cnt.ToString(numberMask));

                            lviS.CompareResultTag = CompareItem.CompareResult.Equal;
                            lviD.CompareResultTag = CompareItem.CompareResult.Equal;
                            lviS.ItemSourceTag = CompareItem.ItemSource.Original;
                            lviD.ItemSourceTag = CompareItem.ItemSource.Original;

                            summary.LinesMatch++;

                            lviS.BackColor = Color.White;
                            lviD.BackColor = Color.White;

                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Line);
                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Size);
                            lviS.SubItems.Add(
                                (sourceDiffList.GetByIndex(drs.SourceIndex + i)).Type.ToString());
                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Path);

                            if ((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Type ==
                                PathType.Directory)
                            {
                                lviS.ImageIndex = 0;
                            }
                            else
                            {
                                lviS.ImageIndex = 1;
                            }

                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Line);
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Size);
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Type.
                                    ToString());
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Path);


                            if ((destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Type ==
                                PathType.Directory)
                            {
                                lviD.ImageIndex = 0;
                            }
                            else
                            {
                                lviD.ImageIndex = 1;
                            }

                       

                            ListFiles1.Add(lviS);
                            ListFiles2.Add(lviD);
                            cnt++;
                        }

                        break;
                    case CompareResultSpanStatus.AddDestination:
                        for (int i = 0; i < drs.Length; i++)
                        {
                            lviS = new CompareItem(cnt.ToString(numberMask));
                            lviD = new CompareItem(cnt.ToString(numberMask));

                            DifferenceLines.Add(cnt);

                            lviS.CompareResultTag = CompareItem.CompareResult.Delete;
                            lviD.CompareResultTag = CompareItem.CompareResult.Delete;
                            lviS.ItemSourceTag = CompareItem.ItemSource.NotInOriginal;
                            lviD.ItemSourceTag = CompareItem.ItemSource.Original;

                            summary.LinesRightOnly++;

                            //Gray
                            lviS.BackColor = Color.FromArgb(224, 224, 224);
                            //Light Coral
                            lviD.BackColor = Color.FromArgb(241, 213, 214);

                            lviS.SubItems.Add("");


                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Line);
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Size);
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Type.
                                    ToString());
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Path);

                            if ((destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Type ==
                                PathType.Directory)
                            {
                                lviD.ImageIndex = 0;
                            }
                            else
                            {
                                lviD.ImageIndex = 1;
                            }

                          


                            ListFiles1.Add(lviS);
                            ListFiles2.Add(lviD);

                            cnt++;
                        }

                        break;
                    case CompareResultSpanStatus.Replace:
                        for (int i = 0; i < drs.Length; i++)
                        {
                            lviS = new CompareItem(cnt.ToString(numberMask));
                            lviD = new CompareItem(cnt.ToString(numberMask));

                            lviS.CompareResultTag = CompareItem.CompareResult.Replace;
                            lviD.CompareResultTag = CompareItem.CompareResult.Replace;
                            lviS.ItemSourceTag = CompareItem.ItemSource.Original;
                            lviD.ItemSourceTag = CompareItem.ItemSource.Original;

                            summary.LinesDifferent++;

                            DifferenceLines.Add(cnt);

                            //Green
                            lviS.BackColor = Color.FromArgb(208, 236, 204);
                            lviD.BackColor = Color.FromArgb(208, 236, 204);

                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Line);
                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Size);
                            lviS.SubItems.Add(
                                (sourceDiffList.GetByIndex(drs.SourceIndex + i)).Type.ToString());
                            lviS.SubItems.Add((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Path);


                            if ((sourceDiffList.GetByIndex(drs.SourceIndex + i)).Type ==
                                PathType.Directory)
                            {
                                lviS.ImageIndex = 0;
                            }
                            else
                            {
                                lviS.ImageIndex = 1;
                            }

                  

                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Line);
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Size);
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Type.
                                    ToString());
                            lviD.SubItems.Add(
                                (destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Path);

                            if ((destinationDiffList.GetByIndex(drs.DestinationIndex + i)).Type ==
                                PathType.Directory)
                            {
                                lviD.ImageIndex = 0;
                            }
                            else
                            {
                                lviD.ImageIndex = 1;
                            }

                        


                            ListFiles1.Add(lviS);
                            ListFiles2.Add(lviD);
                            cnt++;
                        }

                        break;
                }
            }
        }

        #endregion

        #region Privete Methids

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

        #endregion

        #region BackgroundWorker

        private void backgroundWorkerDifference_DoWork(object sender, DoWorkEventArgs e)
        {
            startTime = DateTime.Now;
            FileInfo fileInfo;

            backgroundWorkerDifference.WorkerReportsProgress = true;

            var fileCompareInfo = (FileCompareInfo) e.Argument;
            backgroundWorkerDifference.ReportProgress(5);


            if (fileCompareInfo.ComparePathType == PathType.ListItems)
            {
                var LineItems1 = new List<string>();
                var LineItems2 = new List<string>();
                backgroundWorkerDifference.ReportProgress(15);
                foreach (CompareItem item in fileCompareInfo.ListViewItems1)
                {
                    if (item.ItemSourceTag != CompareItem.ItemSource.NotInOriginal)
                    {
                        LineItems1.Add(item.SubItems[1].Text);
                    }
                }
                foreach (CompareItem item in fileCompareInfo.ListViewItems2)
                {
                    if (item.ItemSourceTag != CompareItem.ItemSource.NotInOriginal)
                    {
                        LineItems2.Add(item.SubItems[1].Text);
                    }
                }

                sourceDiffList = new CompareText(LineItems1);
                destinationDiffList = new CompareText(LineItems2);
            }
            else if (fileCompareInfo.ComparePathType == PathType.Line)
            {
                var LineItems1 = new List<string>();
                var LineItems2 = new List<string>();
                backgroundWorkerDifference.ReportProgress(15);
                foreach (char s in fileCompareInfo.Line1)
                {
                    LineItems1.Add(s.ToString());
                }
                foreach (char s in fileCompareInfo.Line2)
                {
                    LineItems2.Add(s.ToString());
                }

                sourceDiffList = new CompareText(LineItems1);
                destinationDiffList = new CompareText(LineItems2);
            }
            else if (fileCompareInfo.ComparePathType == PathType.Directory)
            {
                List<DirectoryItem> sourceDirectoryListing = DirectoryHelper.GetDirectoryInfo(fileCompareInfo.SourceFile);
                List<DirectoryItem> destinationDirectoryListing = DirectoryHelper.GetDirectoryInfo(fileCompareInfo.DestinationFile);
                backgroundWorkerDifference.ReportProgress(50);

                sourceDiffList = new CompareText(sourceDirectoryListing);
                destinationDiffList = new CompareText(destinationDirectoryListing);
            }
            else //File
            {
                try
                {
                    fileInfo = new FileInfo(fileCompareInfo.SourceFile);

                    if (fileInfo.Exists)
                    {
                        sourceDiffList = new CompareText(fileCompareInfo.SourceFile);
                    }
                    else
                    {
                        sourceDiffList = new CompareText();
                    }

                    fileInfo = new FileInfo(fileCompareInfo.DestinationFile);

                    if (fileInfo.Exists)
                    {
                        destinationDiffList = new CompareText(fileCompareInfo.DestinationFile);
                    }
                    else
                    {
                        destinationDiffList = new CompareText();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Loading Files to Compare", MessageBoxButtons.OK);
                    return;
                }
            }

            backgroundWorkerDifference.ReportProgress(65);

            var compareEngine = new CompareEngine.CompareEngine();
            backgroundWorkerDifference.ReportProgress(70);
            compareEngine.StartDiff(sourceDiffList, destinationDiffList);
            backgroundWorkerDifference.ReportProgress(80);

            resultLines = compareEngine.DiffResult();
            backgroundWorkerDifference.ReportProgress(90);

            //Load ListView Items
            if (fileCompareInfo.ComparePathType == PathType.Line)
            {
            }
            else if (fileCompareInfo.ComparePathType == PathType.Directory)
            {
                DisplayDirectoryResults(sourceDiffList, destinationDiffList, resultLines);
            }
            else
            {
                DistplayFileResults(sourceDiffList, destinationDiffList, resultLines);
            }

            backgroundWorkerDifference.ReportProgress(95);
        }

        private void backgroundWorkerDifference_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarCompare.Value = e.ProgressPercentage;
        }

        private void backgroundWorkerDifference_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBarCompare.Value = 80;
            Refresh();

            if (ComparisonPathType == PathType.Line)
            {
                var editLine = new EditLine(Line1, Line2);
                editLine.Show();
            }
            else
            {
                if (ComparisonPathType == PathType.ListItems)
                {
                    ComparisonPathType = PathType.File;
                }
                var fileComparisonResults
                    = new ComparisonResults
                        (
                        ListFiles1,
                        ListFiles2,
                        DifferenceLines,
                        startTime,
                        txtPath1.Text,
                        txtPath2.Text,                    
                        ComparisonPathType,
                        summary
                        );
                fileComparisonResults.WindowState = FormWindowState.Maximized;
                fileComparisonResults.Show();
            }


            progressBarCompare.Value = 100;
            Refresh();

            Cursor = Cursors.Default;

            Close();
        }

        #endregion

        #region Events

        private void CalculateDifference_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            progressBarCompare.Focus();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            backgroundWorkerDifference.CancelAsync();

            if (Application.OpenForms.Count < 2)
            {
                var comparisonType = new ComparisonType();
                comparisonType.Show();
            }

            Close();
        }

        private void ComparisonProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count < 2)
            {
                Application.Exit();
            }
        }

        #endregion

       
    }
}