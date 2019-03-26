using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using CodeCompare.Shared;

namespace CodeCompare.Forms
{
    public partial class FileIOProgress : BaseForm
    {
        public  class FileCopyInfo
        {
            public string SourcePath;
            public string DestinationPath;
        }

        private readonly FileCopyInfo fileCopyInfo;
        private readonly ComparisonResults.RefreshAndCloseDelegate refreshAndCloseDelegate;

        public FileIOProgress(string SourcePath, string DestinationPath, ComparisonResults.RefreshAndCloseDelegate rCD)
        {
            InitializeComponent();

            fileCopyInfo = new FileCopyInfo();

            fileCopyInfo.SourcePath = SourcePath;
            fileCopyInfo.DestinationPath = DestinationPath;
            refreshAndCloseDelegate = rCD;
        }

        private int CopyDirectory(string Src, string Dst)
        {
            int progress = 0;

            if (Dst[Dst.Length - 1] != Path.DirectorySeparatorChar)
            {
                Dst += Path.DirectorySeparatorChar;
            }
            if (!Directory.Exists(Dst))
            {
                Directory.CreateDirectory(Dst);
            }
            
            if (progress < 100)
            {
                progress++;
                CopyWorker.ReportProgress(progress);
            }

            String[] Files = Directory.GetFileSystemEntries(Src);

            foreach (string Element in Files)
            {
                

                // Sub directories
                if (Directory.Exists(Element))
                {
                    progress+=CopyDirectory(Element, Dst + Path.GetFileName(Element));

                    if (progress > 100)
                    {
                        progress = 100; 
                    }

                    CopyWorker.ReportProgress(progress);
                }
                // Files in directory
                else
                {
                    File.Copy(Element, Dst + Path.GetFileName(Element), true);
                    
                    if (progress < 100)
                    {
                        progress++;
                        CopyWorker.ReportProgress(progress);
                    }
                }
            }
            return progress;
        }

        private void CopyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            FileCopyInfo finfo = (FileCopyInfo)e.Argument;

            CopyDirectory(finfo.SourcePath, finfo.DestinationPath);

            CopyWorker.ReportProgress(100);
        }

        private void FileIOProgress_Load(object sender, EventArgs e)
        {
            txtPath1.Text = fileCopyInfo.SourcePath;
            txtPath2.Text = fileCopyInfo.DestinationPath;
            Cursor = Cursors.WaitCursor;
            CopyWorker.RunWorkerAsync(fileCopyInfo);
            
        }

        private void CopyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            CloseForm();
        }

        private void CopyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarCompare.Value = e.ProgressPercentage;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CopyWorker.CancelAsync();
            CloseForm();
        }
        private void CloseForm()
        {
            refreshAndCloseDelegate();
            Close(); 
        }


    }
}