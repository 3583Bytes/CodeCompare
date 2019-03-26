using System.Diagnostics;

namespace CompareEngine
{
    internal class CompareState
    {
        private const int BAD_INDEX = -1;
        private int _length;
        private int _startIndex;

        public CompareState()
        {
            _startIndex = BAD_INDEX;
            _length = (int)CompareStatus.Unknown;
        }

        public int StartIndex
        {
            get { return _startIndex; }
        }

        public int EndIndex
        {
            get { return ((_startIndex + _length) - 1); }
        }

        public int Length
        {
            get
            {
                int len;
                if (_length > 0)
                {
                    len = _length;
                }
                else
                {
                    len = _length == 0 ? 1 : 0;
                }
                return len;
            }
        }

        public CompareStatus Status
        {
            get
            {
                CompareStatus stat;
                if (_length > 0)
                {
                    stat = CompareStatus.Matched;
                }
                else
                {
                    switch (_length)
                    {
                        case -1:
                            stat = CompareStatus.NoMatch;
                            break;
                        default:
                            Debug.Assert(_length == -2, "Invalid status: _length < -2");
                            stat = CompareStatus.Unknown;
                            break;
                    }
                }
                return stat;
            }
        }

        protected void SetToUnkown()
        {
            _startIndex = BAD_INDEX;
            _length = (int)CompareStatus.Unknown;
        }

        public void SetMatch(int start, int length)
        {
            _startIndex = start;
            _length = length;
        }

        public void SetNoMatch()
        {
            _startIndex = BAD_INDEX;
            _length = (int)CompareStatus.NoMatch;
        }

        public bool HasValidLength(int newStart, int newEnd, int maxPossibleDestLength)
        {
            if (_length > 0) //have unlocked match
            {
                if ((maxPossibleDestLength < _length) ||
                    ((_startIndex < newStart) || (EndIndex > newEnd)))
                {
                    SetToUnkown();
                }
            }
            return (_length != (int)CompareStatus.Unknown);
        }
    }
}
