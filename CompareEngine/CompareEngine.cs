using System;
using System.Collections;

namespace CompareEngine
{
    public class CompareEngine
    {
        private CompareText sourceList;
        private CompareText destList;
        private CompareStateList compareStateList;
        private ArrayList matchList;

        //Constructor
        public CompareEngine()
        {
            //Left Side to Compare
            sourceList = null;
            //Right Side to Compare            
            destList = null;

            matchList = null;

            compareStateList = null;
        }

        //Start Diff betwween two files parsed into 2 objects
        public void StartDiff(CompareText source, CompareText dest)
        {
            if (source.Count() <= 0 && dest.Count() <= 0)
            {
                return;
            }

            //Save to Local vars for later use
            sourceList = source;
            destList = dest;

            matchList = new ArrayList();

            compareStateList = new CompareStateList(destList.Count());
            RecursiveComparer(0, destList.Count() - 1, 0, sourceList.Count() - 1);
        }

        //This is the actual recursive search that looks for longes common-subsequence
        private void RecursiveComparer(int destinationStart, int destinationEnd, int sourceStart, int sourceEnd)
        {
            int curBestIndex = -1;
            int curBestLength = -1;
            CompareState currentItem;
            CompareState bestItem = null;

            for (int count = destinationStart; count <= destinationEnd; count++)
            {
                int maxPossibleDestLength = (destinationEnd - count) + 1;

                if (maxPossibleDestLength <= curBestLength)
                {
                    //not enough text remaining to be larger then the current best
                    break;
                }

                currentItem = compareStateList.GetByIndex(count);

                if (!currentItem.HasValidLength(sourceStart, sourceEnd, maxPossibleDestLength))
                {
                    //recalc new best length since it isn't valid or has never been done.
                    GetLongestSourceMatch(currentItem, count, destinationEnd, sourceStart, sourceEnd);
                }
                if (currentItem.Status == CompareStatus.Matched)
                {
                    if (currentItem.Length > curBestLength)
                    {
                        //this is longest match so far
                        curBestIndex = count;
                        curBestLength = currentItem.Length;
                        bestItem = currentItem;
                    }
                    break;
                }
            }
            if (curBestIndex < 0)
            {
                //we are done - there are no matches in this span
            }
            else
            {
                int sourceIndex = 0;

                if (bestItem != null)
                {
                    sourceIndex = bestItem.StartIndex;
                }

                matchList.Add(CompareResultSpan.CreateNoChange(curBestIndex, sourceIndex, curBestLength));
                if (destinationStart < curBestIndex)
                {
                    //Still have more lower destination data
                    if (sourceStart < sourceIndex)
                    {
                        //Still have more lower source data
                        // Recursive call to process lower indexes
                        RecursiveComparer(destinationStart, curBestIndex - 1, sourceStart, sourceIndex - 1);
                    }
                }
                int upperDestStart = curBestIndex + curBestLength;
                int upperSourceStart = sourceIndex + curBestLength;
                if (destinationEnd > upperDestStart)
                {
                    //we still have more upper dest data
                    if (sourceEnd > upperSourceStart)
                    {
                        //set still have more upper source data
                        // Recursive call to process upper indexes
                        RecursiveComparer(upperDestStart, destinationEnd, upperSourceStart, sourceEnd);
                    }
                }
            }
        }

        private int GetSourceMatchLength(int destIndex, int sourceIndex, int maxLength)
        {
            int matchCount;
            for (matchCount = 0; matchCount < maxLength; matchCount++)
            {
                if (
                    destList.GetByIndex(destIndex + matchCount).CompareTo(sourceList.GetByIndex(sourceIndex + matchCount)) != 0)
                {
                    break;
                }
            }
            return matchCount;
        }

        private void GetLongestSourceMatch(CompareState curItem, int destIndex, int destEnd, int sourceStart,
                                           int sourceEnd)
        {
            int maxDestLength = (destEnd - destIndex) + 1;

            int curBestLength = 0;
            int curBestIndex = -1;

            for (int sourceIndex = sourceStart; sourceIndex <= sourceEnd; sourceIndex++)
            {
                int maxLength = Math.Min(maxDestLength, (sourceEnd - sourceIndex) + 1);
                if (maxLength <= curBestLength)
                {
                    //No chance to find a longer one any more
                    break;
                }
                int curLength = GetSourceMatchLength(destIndex, sourceIndex, maxLength);
                if (curLength > curBestLength)
                {
                    //This is the best match so far
                    curBestIndex = sourceIndex;
                    curBestLength = curLength;
                }
                //jump over the match
                sourceIndex += curBestLength;
            }
            //DiffState cur = _stateList.GetByIndex(destIndex);
            if (curBestIndex == -1)
            {
                curItem.SetNoMatch();
            }
            else
            {
                curItem.SetMatch(curBestIndex, curBestLength);
            }
        }

        private static bool AddChanges(
           
            IList report,
            int curDest,
            int nextDest,
            int curSource,
            int nextSource)
        {
            bool retval = false;
            int diffDest = nextDest - curDest;
            int diffSource = nextSource - curSource;
            if (diffDest > 0)
            {
                if (diffSource > 0)
                {
                    int minDiff = Math.Min(diffDest, diffSource);
                    report.Add(CompareResultSpan.CreateReplace(curDest, curSource, minDiff));
                    if (diffDest > diffSource)
                    {
                        curDest += minDiff;
                        report.Add(CompareResultSpan.CreateAddDestination(curDest, diffDest - diffSource));
                    }
                    else
                    {
                        if (diffSource > diffDest)
                        {
                            curSource += minDiff;
                            report.Add(CompareResultSpan.CreateDeleteSource(curSource, diffSource - diffDest));
                        }
                    }
                }
                else
                {
                    report.Add(CompareResultSpan.CreateAddDestination(curDest, diffDest));
                }
                retval = true;
            }
            else
            {
                if (diffSource > 0)
                {
                    report.Add(CompareResultSpan.CreateDeleteSource(curSource, diffSource));
                    retval = true;
                }
            }
            return retval;
        }

        public ArrayList DiffResult()
        {
            ArrayList retval = new ArrayList();
            int dcount = destList.Count();
            int scount = sourceList.Count();

            //Deal with the special case of empty files
            if (dcount == 0)
            {
                if (scount > 0)
                {
                    retval.Add(CompareResultSpan.CreateDeleteSource(0, scount));
                }
                return retval;
            }
          
            if (scount == 0)
            {
                retval.Add(CompareResultSpan.CreateAddDestination(0, dcount));
                return retval;
            }

            matchList.Sort();
            int curDest = 0;
            int curSource = 0;
            CompareResultSpan last = null;

            //Process each match record
            foreach (CompareResultSpan drs in matchList)
            {
                if ((!AddChanges(retval, curDest, drs.DestinationIndex, curSource, drs.SourceIndex)) &&
                    (last != null))
                {
                    last.AddLength(drs.Length);
                }
                else
                {
                    retval.Add(drs);
                }
                curDest = drs.DestinationIndex + drs.Length;
                curSource = drs.SourceIndex + drs.Length;
                last = drs;
            }

            //Process any tail end data
            AddChanges(retval, curDest, dcount, curSource, scount);

            return retval;
        }
    }  
}