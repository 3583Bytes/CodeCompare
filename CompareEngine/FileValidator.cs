using System.IO;

namespace CompareEngine
{
    public static class FileValidator
    {
        public static bool ValidFile(string fileName)
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

        public static bool ValidDirectory(string dirName)
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
    }
}
