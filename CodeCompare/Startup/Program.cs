using System;
using System.IO;
using System.Windows.Forms;
using CodeCompare.Forms;
using CodeCompare.Shared;

namespace CodeCompare
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CurrentArgType currentType = CurrentArgType.None;
            
            Settings.ExecutablePath = Path.GetDirectoryName(Application.ExecutablePath);
            Settings.UserAppDataPath = Application.UserAppDataPath.Remove(Application.UserAppDataPath.Length-8);

            if (Directory.Exists(Settings.UserAppDataPath) == false)
            {
                Settings.UserAppDataPath = Application.UserAppDataPath;
            }

            Settings.LoadSettings();

            bool foundContextMenu = false;

            if (args != null)
            {
                foreach (string s in args)
                {
                    if (s == "-Path1")
                    {
                        currentType = CurrentArgType.Path1;
                    }
                    else if (s == "-Path2")
                    {
                        currentType = CurrentArgType.Path2;
                    }
                    else if (s == "-Option")
                    {
                        currentType = CurrentArgType.Option;
                    }
                    else if (s == "-Type")
                    {
                        currentType = CurrentArgType.Type;
                    }
                    else if (s == "-LeftSide")
                    {
                        currentType = CurrentArgType.LeftSide;
                    }
                    else if (s == "-RightSide")
                    {
                        currentType = CurrentArgType.RightSide;
                    }
                    else
                    {
                        if (currentType == CurrentArgType.Path1)
                        {
                            Settings.Path1 = s;
                        }
                        else if (currentType == CurrentArgType.Path2)
                        {
                            Settings.Path2 = s;
                        }
                        else if (currentType == CurrentArgType.Option)
                        {
                            if (s == "Fast")
                            {
                                Settings.ComparisonOption = CompareOption.Fast;
                            }
                            if (s == "Medium")
                            {
                                Settings.ComparisonOption = CompareOption.Medium;
                            }
                            if (s == "Slow")
                            {
                                Settings.ComparisonOption = CompareOption.Slow;
                            }
                        }
                        else if (currentType == CurrentArgType.Type)
                        {
                            if (s == "File")
                            {
                                Settings.ComparisonType = CompareType.File;
                            }
                            if (s == "Directory")
                            {
                                Settings.ComparisonType = CompareType.Directory;
                            }
                        }
                        else if (currentType == CurrentArgType.LeftSide)
                        {
                            Settings.LeftPath = s;
                            foundContextMenu = true;
                        }
                        else if (currentType == CurrentArgType.RightSide)
                        {
                            Settings.RightPath = s;
                            foundContextMenu = true;
                        }
                    }
                }
            }

            if (foundContextMenu == false)
            {
                Settings.LeftPath = string.Empty;
                Settings.RightPath = string.Empty;
            }
            else
            {
                if (String.IsNullOrEmpty(Settings.LeftPath) == false)
                {
                    if (String.IsNullOrEmpty(Settings.RightPath))
                    {
                        Settings.SaveSettings();
                        return;
                    }
                    else
                    {
                        Settings.Path1 = Settings.LeftPath;
                        Settings.Path2 = Settings.RightPath;

                        Settings.LeftPath = string.Empty;
                        Settings.RightPath = string.Empty;

                        Settings.SaveSettings();

                    }
                }
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
		

            ComparisonType comparisonType = new ComparisonType();
            comparisonType.Show();

            
            try
            {
                Application.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Exception", MessageBoxButtons.OK);
            }
        }

        #region Nested type: CurrentArgType

        private enum CurrentArgType
        {
            None,
            Path1,
            Path2,
            Option,
            Type,
            LeftSide,
            RightSide
        }

        #endregion
    }
}