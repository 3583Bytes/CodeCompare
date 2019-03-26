using System;
using System.Collections;
using CompareEngine;

namespace CodeCompareConsole
{
    public static class CLIComparer
    {
        public static int consoleWidth;
        public static int consoleHeight;

        public static int DiffsCounter;
        public static int MissingSourceCounter;
        public static int MissingDestCounter;

        public static string LeftSide = "";
        public static string RightSide = "";


        public static ArrayList DiffLines;

        public static void Init()
        {
            consoleHeight = Console.WindowHeight;
            consoleWidth = Console.WindowWidth;

            DiffLines = new ArrayList();

            DiffsCounter = 0;
            MissingSourceCounter = 0;
            MissingDestCounter = 0;

        }

        public static bool GetFiles(string[] args)
        {
          
            //Get Arguments
            if (args != null)
            {
                foreach (string s in args)
                {
                    if (String.IsNullOrEmpty(LeftSide))
                    {
                        LeftSide = s;
                    }
                    else if (String.IsNullOrEmpty(RightSide))
                    {
                        RightSide = s;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //If I did not pass files in arguments then ask user for files
            if (String.IsNullOrEmpty(LeftSide) || String.IsNullOrEmpty(RightSide))
            {
                Console.WriteLine("Drag and Drop Path to File 1 (then press enter):\n");
                LeftSide = Console.ReadLine();

                Console.WriteLine("\nDrag and Drop Path to File 2 (then press enter):\n");
                RightSide = Console.ReadLine();
            }

   
            //Check if I have 2 valid files to compare
            if (!FileValidator.ValidFile(LeftSide))
            {
                CLIComparer.InvalidFile(LeftSide);
                return false;
            }
            if (!FileValidator.ValidFile(RightSide))
            {
                CLIComparer.InvalidFile(RightSide);
                return false;
            }

            return true;
        }


        public static void ShowHeader()
        {
            Console.WriteLine("Code Compare\n");
        }

        public static void InvalidFile(string fileName)
        {
            Console.WriteLine("Invalid File Passed: " + fileName);
        }

        public static void ShowDetails()
        {
            Console.WriteLine("\nDetails:\n\nTotal Diffs:" + DiffsCounter + "\nMissing File 1: " + MissingSourceCounter + "\nMissing File 2: " + MissingDestCounter);


            foreach (string line in DiffLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("\nS: Summary Q: Quit R: Refresh");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);


            if (keyInfo.Key == ConsoleKey.S)
            {
                ShowSummary();
            }
            else if (keyInfo.Key == ConsoleKey.Q)
            {
                Quit();
            }
            else if (keyInfo.Key == ConsoleKey.R)
            {
                CompareFiles();
            }
        }

        public static void Quit()
        {
            return;
        }

        public static void ShowSummary()
        {
            //Show Summary
            Console.WriteLine("\nSummary:\n\nTotal Diffs:" + DiffsCounter + "\nMissing Lines File 1: " + MissingSourceCounter + "\nMissing Lines File 2: " + MissingDestCounter);
            //Show Top 5
            Console.WriteLine("\nFirst 5 Lines:\n");
           
            int c = 0;
            foreach (string line in DiffLines)
            {
                Console.WriteLine(line);
                c++;
                if (c>4)
                {
                    break;
                }
            }
            Console.WriteLine("\nD: Details Q: Quit R: Refresh");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key==ConsoleKey.D)
            {
                ShowDetails();
            }
            else if (keyInfo.Key == ConsoleKey.Q)
            {
                Quit();
            }
            else if (keyInfo.Key == ConsoleKey.R)
            {
               CompareFiles();
            }
            else
            {
                ShowSummary();
            }
        }

        public static void CompareFiles()
        {
            CLIComparer.Init();

            //If I am here I have valid files, start comparing
            CompareEngine.CompareEngine compareEngine = new CompareEngine.CompareEngine();

            //Load the file paths into objects
            CompareText sourceDiffList = new CompareText(LeftSide);
            CompareText destinationDiffList = new CompareText(RightSide);
            //Perform the comparison
            compareEngine.StartDiff(sourceDiffList, destinationDiffList);
            //Get Results
            ArrayList resultLines = compareEngine.DiffResult();
            string numberMask = GetNumberMask(sourceDiffList.Count(), destinationDiffList.Count());

            int lineCounter = 1;

            foreach (CompareResultSpan compareResultSpan in resultLines)
            {
                switch (compareResultSpan.Status)
                {
                    case CompareResultSpanStatus.DeleteSource:
                        for (int i = 0; i < compareResultSpan.Length; i++)
                        {
                            string initial = "";
                            string rewrite = "";

                            initial += lineCounter.ToString(numberMask);
                            rewrite += lineCounter.ToString(numberMask);

                            initial += " < " + sourceDiffList.GetByIndex(compareResultSpan.SourceIndex + i).Line + "";

                            CLIComparer.DiffLines.Add(initial);

                            lineCounter++;
                            CLIComparer.MissingSourceCounter++;
                        }

                        break;
                    case CompareResultSpanStatus.NoChange:
                        for (int i = 0; i < compareResultSpan.Length; i++)
                        {
                            lineCounter++;
                        }

                        break;
                    case CompareResultSpanStatus.AddDestination:
                        for (int i = 0; i < compareResultSpan.Length; i++)
                        {

                            string rewrite = "";

                            rewrite += lineCounter.ToString(numberMask);


                            rewrite += " > " + destinationDiffList.GetByIndex(compareResultSpan.DestinationIndex + i).Line + "";

                            CLIComparer.DiffLines.Add(rewrite);

                            lineCounter++;
                            CLIComparer.MissingDestCounter++;
                        }

                        break;
                    case CompareResultSpanStatus.Replace:
                        for (int i = 0; i < compareResultSpan.Length; i++)
                        {
                            string initial = "";
                            string rewrite = "";

                            initial += lineCounter.ToString(numberMask);
                            rewrite += lineCounter.ToString(numberMask);

                            initial += " initial:";
                            rewrite += " rewrite:";

                            initial += sourceDiffList.GetByIndex(compareResultSpan.SourceIndex + i).Line;
                            rewrite += destinationDiffList.GetByIndex(compareResultSpan.DestinationIndex + i).Line;

                            CLIComparer.DiffLines.Add(initial);
                            CLIComparer.DiffLines.Add(rewrite);

                            lineCounter++;
                            CLIComparer.DiffsCounter++;
                        }

                        break;
                }
            }

            CLIComparer.ShowSummary();
        }

        private static string GetNumberMask(int sourceDiffListCount, int destinationDiffListCount)
        {
            string numberMask = "000";

            if (sourceDiffListCount > 999 && sourceDiffListCount > destinationDiffListCount)
            {
                for (int x = 0; x < sourceDiffListCount.ToString().Length; x++)
                {
                    numberMask += "0";
                }
            }
            else if (destinationDiffListCount > 999)
            {
                for (int x = 0; x < destinationDiffListCount.ToString().Length; x++)
                {
                    numberMask += "0";
                }
            }

            return numberMask;
        }

    }
}
