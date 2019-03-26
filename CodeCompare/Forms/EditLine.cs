using System;
using System.Drawing;
using System.Windows.Forms;
using CodeCompare.Shared;

namespace CodeCompare.Forms
{
    public partial class EditLine : BaseForm
    {
        public bool checking;
        private bool SideBySide = true;

        private string line1;
        private string line2;

        private int start1;
        private int start2;

        public EditLine(string Line1, string Line2)
        {
            InitializeComponent();

            line1 = Line1;
            line2 = Line2;

            txtLine1.Text = Line1;
            txtLine2.Text = Line2;

            start1 = 0;
            start2 = 0;

            checking = false;
        }

        public string Line1
        {
            get { return line1; }
        }

        public string Line2
        {
            get { return line2; }
        }

        private void CheckForEqual()
        {
            Cursor = Cursors.WaitCursor;

            checking = true;

            if (string.Compare(txtLine1.Text, txtLine2.Text) != 0)
            {
                lblLineDifference.Text = "Lines are NOT Equal";
                lblLineDifference.ForeColor = Color.Red;
            }
            else
            {
                lblLineDifference.Text = "Lines are Equal";
                lblLineDifference.ForeColor = Color.Green;
            }

            txtLine2.Select(0, txtLine2.Text.Length);
            txtLine2.SelectionColor = Color.Green;
            txtLine1.Select(0, txtLine1.Text.Length);
            txtLine1.SelectionColor = Color.Green;

            int CountTotal;

            if (txtLine1.Text.Length >= txtLine2.Text.Length)
            {
                CountTotal = txtLine1.Text.Length;
            }
            else
            {
                CountTotal = txtLine2.Text.Length;
            }

            for (int i = 0; i < CountTotal; i++)
            {
                {
                    if (i < txtLine2.Text.Length && i < txtLine1.Text.Length)
                    {
                        if (txtLine1.Text[i] != txtLine2.Text[i])
                        {
                            txtLine2.Select(i, 1);
                            txtLine2.SelectionColor = Color.Red;
                            txtLine1.Select(i, 1);
                            txtLine1.SelectionColor = Color.Red;
                        }
                    }
                    else if (i < txtLine1.Text.Length)
                    {
                        txtLine1.Select(i, 1);
                        txtLine1.SelectionColor = Color.Red;
                    }
                    else if (i < txtLine2.Text.Length)
                    {
                        txtLine2.Select(i, 1);
                        txtLine2.SelectionColor = Color.Red;
                    }
                }
            }

            txtLine1.Select(start1, 0);

            checking = false;

            Cursor = Cursors.Default;
        }


        private void EditLine_Load(object sender, EventArgs e)
        {
            CheckForEqual();
        }


        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Replace Text: \n\n" + txtLine2.Text + "\n\n With: \n\n" + txtLine1.Text,
                                "Replace Text?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtLine2.Text = txtLine1.Text;
            }
        }


        private void EditLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Application.OpenForms.Count < 2)
            {
                Application.Exit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            line1 = txtLine1.Text;
            line2 = txtLine2.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtLine1_TextChanged(object sender, EventArgs e)
        {
            if (checking == false)
            {
                start1 = txtLine1.SelectionStart;
                CheckForEqual();
                txtLine1.Select(start1, 0);
            }
        }

        private void txtLine2_TextChanged(object sender, EventArgs e)
        {
            if (checking == false)
            {
                start2 = txtLine2.SelectionStart;
                CheckForEqual();
                txtLine2.Select(start2, 0);
            }
        }

        private void EditLine_ResizeEnd(object sender, EventArgs e)
        {
            if (SideBySide)
            {
                ArrangeSideBySide();
            }
            else
            {
                ArrangeTopDown();
            }
        }

        private void ArrangeSideBySide()
        {
            txtLine1.Width = (Width/2) - 20;
            txtLine1.Left = 0;
            txtLine1.Top = 0;
            txtLine1.Height = Height - 60;
            txtLine1.WordWrap = true;
            
            txtLine2.Width = (Width/2) - 20;
            txtLine2.Left = (Width/2) + 20;
            txtLine2.Top = 0;
            txtLine2.Height = Height - 60;
            txtLine2.WordWrap = true;

            btnCopy.Left = (Width/2) - 13;
            
        }

        private void ArrangeTopDown()
        {
            txtLine1.Width = Width - 60;
            txtLine1.Left = 0;
            txtLine1.Top = 0;
            txtLine1.Height = 20;
            txtLine1.WordWrap = false;

            txtLine2.Width = Width - 60;
            txtLine2.Left = 0;
            txtLine2.Top = txtLine1.Height + 1;
            txtLine2.Height = 20;
            txtLine2.WordWrap = false;

            btnCopy.Left = Width - 50;
            btnCopy.Top = txtLine1.Height/2; 
        }

        private void btnChangeView_Click(object sender, EventArgs e)
        {
            if (!SideBySide)
            {
                SideBySide = true;
                ArrangeSideBySide();
            }
            else
            {
                SideBySide = false;
                ArrangeTopDown();
            }
        }
    }
}