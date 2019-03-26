using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CodeCompare.Shared
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        [DllImport("uxtheme", ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern Int32 SetWindowTheme
            (IntPtr hWnd, String textSubAppName, String textSubIdList);
    }
}