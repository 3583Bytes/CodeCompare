using System;
using System.Reflection;
using CodeCompare.Shared;

namespace CodeCompare.Forms
{
    public partial class About : BaseForm
    {
        public About() : base()
        {
            InitializeComponent();
            
            Assembly MyAssembly = Assembly.GetExecutingAssembly();

            Version AppVersion = MyAssembly.GetName().Version;


            string MyVersion = AppVersion.Major
                               + "." + AppVersion.Minor
                               + "." + AppVersion.Build
                               + "." + AppVersion.Revision;

            lblVersion.Text = "Version: " + MyVersion;
        }

    }
}