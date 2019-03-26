using System;
using System.Windows.Forms;
using CodeCompare.Shared;

namespace CodeCompare.Forms
{
    public partial class ComparisonSummary : BaseForm
    {
        private readonly Summary summary;

        public ComparisonSummary(Summary Summary)
        {
            InitializeComponent();
            summary = Summary;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count < 2)
            {
                Application.Exit();
            }
            Close();
        }

        private void ComparisonSummary_Load(object sender, EventArgs e)
        {
            lblMatch.Text = summary.LinesMatch + "  line(s) match";
            lblLeftSideOnly.Text = summary.LinesLeftOnly + " line(s) left side only";
            lblRightSideOnly.Text = summary.LinesRightOnly + " line(s) right side only";
            lblDifference.Text = summary.LinesDifferent + " line(s) with differences";
        }
    }
}