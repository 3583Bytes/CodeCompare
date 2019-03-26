
namespace CompareEngine
{
    internal class CompareStateList
    {
        private readonly CompareState[] compareStateArray;

        public CompareStateList(int destinationCount)
        {
            compareStateArray = new CompareState[destinationCount];
        }

        public CompareState GetByIndex(int index)
        {
            CompareState compareState = compareStateArray[index];
            if (compareState == null)
            {
                compareState = new CompareState();
                compareStateArray[index] = compareState;
            }
            return compareState;
        }
    }
}
