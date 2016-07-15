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

            foreach (var i in badMatchTable)
            {
                Console.WriteLine(i.Key + " -> " + i.Value);
            }

            return 1;
        }

    }
}
