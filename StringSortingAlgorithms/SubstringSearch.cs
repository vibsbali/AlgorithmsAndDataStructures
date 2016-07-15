using System;
using System.Collections.Generic;

namespace StringSortingAlgorithms
{
    public class SubstringSearch
    {
        //This algorithm is better than better than naiive brute force
        //The way I came up with this algorithm is I wrote code without --i part
        //Then I did some tests and realised it fails when input string is drodroped and string to find is droped
        public int BruteForce(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
            {
                return 0;
            }
            if(input.Length < pattern.Length)
            {
                return 0;
            }

            var j = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == pattern[j])
                {
                    j++;
                    if (j == pattern.Length)
                        return i - j;
                }
                else if (j != 0)
                {
                    j = 0;
                    --i; //This is important step - so that we can match drodroped and droped 
                }
            }

            return 0;
        }


        //Boyer-Moore-Horspool algorithm
        /* Create a bad match table ie. for pattern TRUTH the table would be like so
        *                                   T R U
        *                                   1 3 2
        *  Here is how the table is created - looking at pattern TRUTH 
        *  If we match H then it is good and we can start comparing backwards, if there is a mismatch and the character
        *  in string to search in has character U then we should move our TRUTH to 2 indices to right. If it was a R we would have
        *  moved 3 character and if it was T then only 1
        *  If you want to match space then ensure to add space at the begining of the pattern
        */

        public int BoyerMoreHorsepoolAlgorithm(string input, string pattern)
        {
            //Create a bad match table
            var badMatchTable = new Dictionary<char, int>();
            var j = 1;  //We can optimise and remove j but I will leave it for readability
            for (int i = pattern.Length - 2; i >= 0; i--)
            {
                if (!badMatchTable.ContainsKey(pattern[i]))
                {
                    badMatchTable.Add(pattern[i], j);
                    j++;
                }
            }

            //From here on we start the matching process
            var lengthOfPattern = pattern.Length;
            //We want to start matching from left to right so we skip number of items in input equal to pattern' length
            for (int i = lengthOfPattern - 1; i < input.Length; i+=lengthOfPattern)
            {
                //If we find the that right's character of pattern matches with inputString's character
                if (input[i] == pattern[lengthOfPattern - 1])
                {
                    var result = SearchString(input, pattern, 0, i);
                    if (result != -1)
                    {
                        return result;
                    }
                    #region redundant
                    //var currentIndex = lengthOfPattern - 1;
                    //for (int k = i; k >= 0; k--)
                    //{
                    //    if (input[i] == pattern[currentIndex])
                    //    {
                    //        currentIndex--;
                    //        if (currentIndex == 0)
                    //        {
                    //            return k;
                    //        }
                    //    }
                    //}
#endregion
                }
                //Else if we find that right's character of pattern doesnt match with input string' character but the character is in bad match table 
                //i.e. HELLO WORLD is our input string and pattern is OR
                //             OR <- At this stage O And R doesn't match but O is in bad match table 
                else if (input[i] != pattern[lengthOfPattern - 1] && badMatchTable.ContainsKey(input[i]))
                {
                    //get the value which determines our offset
                    var value = badMatchTable[input[i]];
                    var result = SearchString(input, pattern, value, i);
                    if (result != -1)
                    {
                        return result;
                    }
                }
            }

            return -1;
        }
        //Used in conjuction with BoyerMoreHorsepool algorithm
        //Accepts input and pattern string along with offset and index value
        //offset tell how much to the right pattern needs to be matched
        private int SearchString(string input, string pattern, int offset, int index)
        {
            var indexToSearchFrom = pattern.Length - 1;
            //check to ensure that offset + index doesn't cause out of bounds exception for input string
            if (offset + index >= input.Length)
            {
                return -1;
            }
            for (int i = offset + index; i >= 0 && indexToSearchFrom >= 0; i--)
            {
                if (input[i] == pattern[indexToSearchFrom])
                {
                    if (indexToSearchFrom == 0)
                    {
                        return i;
                    }
                    --indexToSearchFrom;
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }
    }
}
