using System;

namespace CompareEngine
{

    public enum CompareStatus
    {
        Matched = 1,
        NoMatch = -1,
        Unknown = -2
    }

    public enum CompareResultSpanStatus
    {
        NoChange,
        Replace,
        DeleteSource,
        AddDestination
    }

    public class CompareResultSpan : IComparable
    {
        private const int BAD_INDEX = -1;
        private readonly int _destIndex;
        private readonly int _sourceIndex;
        private readonly CompareResultSpanStatus _status;
        private int _length;

        protected CompareResultSpan(
            CompareResultSpanStatus status,
            int destinationIndex,
            int sourceIndex,
            int length)
        {
            _status = status;
            _destIndex = destinationIndex;
            _sourceIndex = sourceIndex;
            _length = length;
        }

        public int DestinationIndex
        {
            get { return _destIndex; }
        }

        public int SourceIndex
        {
            get { return _sourceIndex; }
        }

        public int Length
        {
            get { return _length; }
        }

        public CompareResultSpanStatus Status
        {
            get { return _status; }
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return _destIndex.CompareTo(((CompareResultSpan) obj)._destIndex);
        }

        #endregion

        public static CompareResultSpan CreateNoChange(int destinationIndex, int sourceIndex, int length)
        {
            return new CompareResultSpan(CompareResultSpanStatus.NoChange, destinationIndex, sourceIndex, length);
        }

        public static CompareResultSpan CreateReplace(int destinationIndex, int sourceIndex, int length)
        {
            return new CompareResultSpan(CompareResultSpanStatus.Replace, destinationIndex, sourceIndex, length);
        }

        public static CompareResultSpan CreateDeleteSource(int sourceIndex, int length)
        {
            return new CompareResultSpan(CompareResultSpanStatus.DeleteSource, BAD_INDEX, sourceIndex, length);
        }

        public static CompareResultSpan CreateAddDestination(int destinationIndex, int length)
        {
            return new CompareResultSpan(CompareResultSpanStatus.AddDestination, destinationIndex, BAD_INDEX, length);
        }

        public void AddLength(int length)
        {
            _length += length;
        }

        public override string ToString()
        {
            return string.Format("{0} (Dest: {1},Source: {2}) {3}",
                                 _status,
                                 _destIndex,
                                 _sourceIndex,
                                 _length);
        }

        

    }
}