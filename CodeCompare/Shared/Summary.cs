namespace CodeCompare.Shared
{
    public class Summary
    {
        public int LinesDifferent;
        public int LinesLeftOnly;
        public int LinesMatch;
        public int LinesRightOnly;


        public Summary()
        {
            LinesMatch = 0;
            LinesLeftOnly = 0;
            LinesRightOnly = 0;
            LinesDifferent = 0;
        }
    }
}