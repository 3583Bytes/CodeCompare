using System;

namespace CompareEngine
{
    public enum PathType
    {
        File,
        Directory,
        Line,
        ListItems
    }

    public class DirectoryItem
    {
        private string name;
        private string path;
        private string size;
        private DateTime lastWrite;
        private PathType type;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public PathType Type
        {
            get { return type; }
            set { type = value; }
        }

        public DateTime LastWrite
        {
            get { return lastWrite; }
            set { lastWrite = value; }
        }

        public string Size
        {
            get { return size; }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    if (long.Parse(value) < 1024)
                    {
                        size = (long.Parse(value)).ToString("###,###,###,###") + " B";
                        if (size == " B")
                        {
                            size = "0 KB";
                        }
                    }
                    else
                    {
                        size = (long.Parse(value) / 1024).ToString("###,###,###,###") + " KB";
                        if (size == " KB")
                        {
                            size = "0 KB";
                        }
                    }
                    
                }
                else
                {
                    size = "0 KB";
                }
            }
        }
    }
}