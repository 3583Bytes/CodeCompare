using System;
using System.Collections.Generic;
using System.IO;
using CompareEngine;

namespace CodeCompare.Shared
{
    public static class DirectoryHelper
    {
        private static long DirectorySize(DirectoryInfo d)
        {
            try
            {
                long Size = 0L;
                // Add file sizes.
                FileInfo[] fis = d.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    Size += fi.Length;
                }
                // Add subdirectory sizes.
                DirectoryInfo[] dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    Size += DirectorySize(di);
                }
                return (Size);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static List<DirectoryItem> GetDirectoryInfo(string directoryPath)
        {
            int progress = 20;
            var directoryListing = new List<DirectoryItem>();
            DirectoryItem directoryItem;

            var directoryInfo = new DirectoryInfo(directoryPath + "\\");

            if (directoryInfo.Exists == false)
            {
                return directoryListing;
            }

            directoryInfo.GetFiles();

            DirectoryInfo[] subDirectories = directoryInfo.GetDirectories();
            FileInfo[] subFiles = directoryInfo.GetFiles();

            foreach (DirectoryInfo subDir in subDirectories)
            {
                directoryItem = new DirectoryItem();
                directoryItem.Name = subDir.Name;
                directoryItem.LastWrite = subDir.LastWriteTime;

                directoryItem.Path = subDir.FullName;
                directoryItem.Type = PathType.Directory;
                directoryItem.Size = DirectorySize(subDir).ToString();
                directoryListing.Add(directoryItem);
                if (progress < 90)
                {
                    progress++;

                }
            }
            foreach (FileInfo fileInfo in subFiles)
            {
                directoryItem = new DirectoryItem();
                directoryItem.Name = fileInfo.Name;
                directoryItem.Path = Path.GetDirectoryName(fileInfo.FullName);
                directoryItem.Type = PathType.File;
                directoryItem.Size = fileInfo.Length.ToString();
                directoryItem.LastWrite = fileInfo.LastWriteTime;


                directoryListing.Add(directoryItem);
                if (progress < 90)
                {
                    progress++;

                }
            }


            directoryListing.Sort
                (
                    delegate(DirectoryItem d1, DirectoryItem d2)
                    {
                        if (d1.Type == d2.Type)
                        {
                            return d1.Name.CompareTo(d2.Name);
                        }
                       
                            if (d1.Type == PathType.Directory)
                            {
                                return -1;
                            }
                            
                            return 1;
                    }
                );
            return directoryListing;
        }


    }
}
