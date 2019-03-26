using System;
using System.IO;
using System.Windows.Forms;
using CodeCompare.Shared;
using CompareEngine;
using System.Diagnostics;

namespace CodeCompare.Forms
{
    public partial class ComparisonType : BaseForm
    {
        
        public ComparisonType()
        {
            InitializeComponent();
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


        private string GetFileName()
        {
            string fileName = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            return fileName;
        }

        private string GetDirectoryName()
        {
            string directoryName = string.Empty;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                directoryName = folderBrowserDialog.SelectedPath;
            }
            return directoryName;
        }

        private bool Compare()
        {
            if (String.IsNullOrEmpty(txtPath1.Text))
            {
                MessageBox.Show("You must specify both paths", "Invalid Path", MessageBoxButtons.OK);
                txtPath1.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(txtPath2.Text))
            {
                MessageBox.Show("You must specify both paths", "Invalid Path", MessageBoxButtons.OK);
                txtPath2.Focus();
                return false;
            }

            try
            {
                if (txtPath1.Text.Substring(txtPath1.Text.Length - 1) == "\\")
                {
                    txtPath1.Text = txtPath1.Text.Remove(txtPath1.Text.Length - 1);
                }
                if (txtPath2.Text.Substring(txtPath2.Text.Length - 1) == "\\")
                {
                    txtPath2.Text = txtPath2.Text.Remove(txtPath2.Text.Length - 1);
                }


                if (ValidFile(txtPath1.Text) == false)
                {
                    if (ValidDirectory(txtPath1.Text) == false)
                    {
                        MessageBox.Show(txtPath1.Text + "\n\n is not a valid path", "Invalid Path", MessageBoxButtons.OK);
                        return false;
                    }
                }
                if (ValidFile(txtPath2.Text) == false)
                {
                    if (ValidDirectory(txtPath2.Text) == false)
                    {
                        MessageBox.Show(txtPath2.Text + "\n\n is not a valid path", "Invalid Path", MessageBoxButtons.OK);
                        return false;
                    }
                }

                if (ValidFile(txtPath1.Text))
                {
                    if (ValidDirectory(txtPath1.Text))
                    {
                        MessageBox.Show("Cannot Compare a file to a directory", "Invalid Comparison", MessageBoxButtons.OK);
                        return false;
                    }
                }
                if (ValidFile(txtPath1.Text))
                {
                    if (ValidDirectory(txtPath1.Text))
                    {
                        MessageBox.Show("Cannot Compare a file to a directory", "Invalid Comparison", MessageBoxButtons.OK);
                        return false;
                    }
                }

                if (String.IsNullOrEmpty(txtPath1.Text) == false && String.IsNullOrEmpty(txtPath2.Text) == false)
                {
                    ComparisonProgress calculateDifference = new ComparisonProgress(txtPath1.Text, txtPath2.Text);

                    calculateDifference.Show();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "There was an error comparing files", MessageBoxButtons.OK);
                return false;
            }
        }


        private void btnPath1_Click(object sender, EventArgs e)
        {
            if (rdoFolders.Checked)
            {
                txtPath1.Text = GetDirectoryName();
            }
            else
            {
                txtPath1.Text = GetFileName();
            }
        }

        private void btnPath2_Click(object sender, EventArgs e)
        {
            if (rdoFolders.Checked)
            {
                txtPath2.Text = GetDirectoryName();
            }
            else
            {
                txtPath2.Text = GetFileName();
            }
        }

        private void ComparisonType_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Path1 = txtPath1.Text;
            Settings.Path2 = txtPath2.Text;

            if (rdoFiles.Checked)
            {
                Settings.ComparisonType = CompareType.File;
            }
            if (rdoFolders.Checked)
            {
                Settings.ComparisonType = CompareType.Directory;
            }

            Settings.SaveSettings();

            if (Application.OpenForms.Count < 2)
            {
                Application.Exit();
            }
        }

        private void ComparisonType_Load(object sender, EventArgs e)
        {
            txtPath1.Text = Settings.Path1;
            txtPath2.Text = Settings.Path2;

            if (Settings.ComparisonType == CompareType.File)
            {
                rdoFiles.Checked = true;
            }
            if (Settings.ComparisonType == CompareType.Directory)
            {
                rdoFolders.Checked = true;
            }
        }

        private void btnAboutShow_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Close();
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            if (Compare())
            {
                Close();
            }
        }


        private void txtPath1_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string fileName in (string[])e.Data.GetData(DataFormats.FileDrop) )
            {
                txtPath1.Text =fileName;
            }
        }

        private void txtPath1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void txtPath2_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string fileName in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                txtPath2.Text = fileName;
            }
        }

        private void txtPath2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                e.Effect = DragDropEffects.All;
            }
        }

        

        
    }
}