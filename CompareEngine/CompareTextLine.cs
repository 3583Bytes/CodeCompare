

namespace CompareEngine
{
    public class CompareTextLine
    {
        public int Hash;
        public string Line;
        public string Path;
        public string Size;
        public PathType Type;


        public CompareTextLine(string line)
        {
            Line = line;
            Hash = line.Replace("\t", "    ").GetHashCode();
            Type = PathType.File;
        }

        public CompareTextLine(string line, PathType type, string path, string size)
        {
            Line = line;


            Hash = ((line + " " + size).Replace("\t", "    ")).GetHashCode();



            Type = type;
            Path = path;
            Size = size;
        }

        public int CompareTo(CompareTextLine compareTextLine)
        {
            return Hash.CompareTo((compareTextLine).Hash);
        }


    }
}
