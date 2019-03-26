using System.Collections.Generic;
using FastListView;
using CompareEngine;

namespace CodeCompare.Shared
{

    public class FileCompareInfo
    {
        private PathType comparePathType;
        private string destinationFile;

        private string line1;
        private string line2;

        private List<CompareItem> listViewItems1;
        private List<CompareItem> listViewItems2;
        private string sourceFile;


        public FileCompareInfo()
        {
            comparePathType = PathType.File;
        }

        public List<CompareItem> ListViewItems1
        {
            get { return listViewItems1; }
            set { listViewItems1 = value; }
        }

        public List<CompareItem> ListViewItems2
        {
            get { return listViewItems2; }
            set { listViewItems2 = value; }
        }

        public string SourceFile
        {
            get { return sourceFile; }
            set { sourceFile = value; }
        }

        public string DestinationFile
        {
            get { return destinationFile; }
            set { destinationFile = value; }
        }

        public string Line1
        {
            get { return line1; }
            set { line1 = value; }
        }

        public string Line2
        {
            get { return line2; }
            set { line2 = value; }
        }

        public PathType ComparePathType
        {
            get { return comparePathType; }
            set { comparePathType = value; }
        }
    }
}