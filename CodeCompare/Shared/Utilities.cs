
namespace CodeCompare.Shared
{
    public static class Utilities
    {

        public static string GetNumberMask(int count)
        {
            string numberMask = "00000";

            if (count.ToString().Length > numberMask.Length)
            {
                numberMask = "";

                foreach (char c in count.ToString())
                {
                    numberMask += "0";
                }

            }

            return numberMask;
        }
    }
}