using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace CompareEngine
{

    public class CompareText
    {
        private const int MaxLineLength = int.MaxValue /2;
        private readonly ArrayList lines;

        public CompareText()
        {
            lines = new ArrayList();
        }


            public CompareText(string fileName)
        {
            lines = new ArrayList();

            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.Default))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length > MaxLineLength)
                    {
                        throw new InvalidOperationException(
                            string.Format("File contains a line greater than {0} characters.",
                                          MaxLineLength));
                    }
                    lines.Add(new CompareTextLine(line));
                }
            }
        }

        public CompareText(IEnumerable<DirectoryItem> directoryItems)
        {
            lines = new ArrayList();

            foreach (DirectoryItem directoryItem in directoryItems)
            {
                if (directoryItem.Name.Length > MaxLineLength)
                {
                    throw new InvalidOperationException(
                        string.Format("File contains a line greater than {0} characters.",
                                      MaxLineLength));
                }
                lines.Add(new CompareTextLine(directoryItem.Name, directoryItem.Type, directoryItem.Path, directoryItem.Size));
            }
        }

        public CompareText(IEnumerable<string> lineItems)
        {
            lines = new ArrayList();


            foreach (String lineItem in lineItems)
            {
                if (lineItem.Length > MaxLineLength)
                {
                    throw new InvalidOperationException(
                        string.Format("File contains a line greater than {0} characters.",
                                      MaxLineLength));
                }
                lines.Add(new CompareTextLine(lineItem));
            }
        }

        public int Count()
        {
            return lines.Count;
        }

        public CompareTextLine GetByIndex(int index)
        {
            return (CompareTextLine) lines[index];
        }

    }
}