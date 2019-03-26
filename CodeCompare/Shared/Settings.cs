using System;
using System.IO;
using System.Xml.Serialization;

namespace CodeCompare.Shared
{
    public enum CompareOption
    {
        Fast,
        Medium,
        Slow
    }

    public enum CompareType
    {
        File,
        Directory
    }

    public static class Settings
    {
        private static CompareOption compareOption = CompareOption.Slow;
        private static CompareType compareType = CompareType.Directory;
        private static string executablePath = string.Empty;
        private static string userAppDataPath = string.Empty;

        private static string leftPath = string.Empty;
        private static string path1 = string.Empty;
        private static string path2 = string.Empty;

        private static bool registry = false;
        private static string rightPath = string.Empty;

        private static bool purchased = false;

        public static bool Registry
        {
            get { return registry; }
            set { registry = value; }
        }

        public static string UserAppDataPath
        {
            get { return userAppDataPath; }
            set { userAppDataPath = value; }
        }

        public static string ExecutablePath
        {
            get { return executablePath; }
            set { executablePath = value; }
        }

        public static string Path1
        {
            get { return path1; }
            set { path1 = value; }
        }

        public static string Path2
        {
            get { return path2; }
            set { path2 = value; }
        }

        public static CompareOption ComparisonOption
        {
            get { return compareOption; }
            set { compareOption = value; }
        }

        public static CompareType ComparisonType
        {
            get { return compareType; }
            set { compareType = value; }
        }

        public static string LeftPath
        {
            get { return leftPath; }
            set { leftPath = value; }
        }

        public static string RightPath
        {
            get { return rightPath; }
            set { rightPath = value; }
        }

        public static bool Purchased
        {
            get { return purchased; }
            set { purchased = value; }
        }

        public static void SaveSettings()
        {
            try
            {
                SettingsXML settingsXML = new SettingsXML();

                settingsXML.Path1 = Path1;
                settingsXML.Path2 = Path2;
                settingsXML.ComparisonOption = ComparisonOption;
                settingsXML.ComparisonType = ComparisonType;
                settingsXML.LeftPath = leftPath;
                settingsXML.RightPath = rightPath;
                settingsXML.Purchased = purchased;

                XmlSerializer serializer = new XmlSerializer(typeof (SettingsXML));
                TextWriter writer = new StreamWriter(userAppDataPath + @"\Settings.xml");
                
                serializer.Serialize(writer, settingsXML);
                writer.Close();
            }
            catch (Exception)
            {
            }
        }

        public static void LoadSettings()
        {
            try
            {
                SettingsXML settingsXML;

                XmlSerializer serializer = new XmlSerializer(typeof (SettingsXML));
                TextReader reader = new StreamReader(userAppDataPath + @"\Settings.xml");

                settingsXML = (SettingsXML) serializer.Deserialize(reader);
                reader.Close();

                Path1 = settingsXML.Path1;
                Path2 = settingsXML.Path2;
                ComparisonOption = settingsXML.ComparisonOption;
                ComparisonType = settingsXML.ComparisonType;
                LeftPath = settingsXML.LeftPath;
                RightPath = settingsXML.RightPath;
                Purchased = settingsXML.Purchased;
            }
            catch (Exception)
            {
            }
        }
    }

    public class SettingsXML
    {
        public CompareOption ComparisonOption = CompareOption.Slow;
        public CompareType ComparisonType;
        public string LeftPath;
        public string Path1;
        public string Path2;
        public string RightPath;
        public bool Purchased;
    }
}