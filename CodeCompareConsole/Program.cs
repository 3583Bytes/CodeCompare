using System;
using System.Collections;


namespace CodeCompareConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CLIComparer.ShowHeader();

            for (int i = 0; i < 5; i++)
            {
                if (CLIComparer.GetFiles(args))
                {
                    break;
                }
                //After tries we exit
                if (i == 4)
                {
                    return;
                }
            }



            CLIComparer.CompareFiles();

           
        }

       

        
    }
}
