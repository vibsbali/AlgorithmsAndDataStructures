/*
1. Partition array into R pieces according to first character
(use key-indexed counting).
2. Recursively sort all strings that start with each character
(key-indexed counts delineate subarrays to sort).
*/


using System;

namespace StringSortingAlgorithms
{
    // ReSharper disable once InconsistentNaming
    public class MSDSort
    {
        private readonly string[] stringArray;
        private readonly int lengthOfArray;
        private readonly string[] aux;
        private int Radix = 256;
        private int cutoff = 15;

        public MSDSort(string[] a)
        {
            stringArray = a;
            lengthOfArray = a.Length;
            aux = new string[lengthOfArray];
        }

        public void SortString()
        {
            Sort(stringArray, 0, lengthOfArray - 1, 0);  //Initially we call sort with digit = 0 i.e. sort of first character
        }

        //sort from a[lo] to a[high], starting at the dth character
        private void Sort(string[] a, int lo, int high, int d)
        {
            //This code is very important without it there will be index out of range exception as strings gets smaller and smaller, and d gets larger 
            if (high <= lo + cutoff)
            {
                Insertion(a, lo, high, d);
                return;
            }

            //create a count array with +2 this time in LSD we had 1
            var count = new int[Radix + 2];

            //create an array of count frequency of each character
            for (int i = lo; i < high; i++)
            {
                count[CharAt(a[i], d) + 2]++;
            }

            //create a (cumulative array) i.e transform counts to indices
            for (int i = lo; i < Radix + 1; i++)
            {
                count[i + 1] += count[i];
            }

            //distribute 
            for (int i = lo; i <= high; i++)
            {
                int c = CharAt(a[i], d)+1;
                aux[count[c]++] = a[i]; //Increment the value
            }

            //copy back
            for (int i = lo; i <= high; i++)
            {
                a[i] = aux[i - lo];
            }

            //recursively sort for each character 
            for (int i = 0; i < Radix; i++)
                Sort(a, lo + count[i], lo + count[i + 1], d + 1);

        }

        private void Insertion(string[] a, int lo, int hi, int d)
        {
            for (int i = lo; i <= hi; i++)
                for (int j = i; j > lo && Less(a[j], a[j - 1], d); j--)
                    Exch(a, j, j - 1);
        }

        // exchange a[i] and a[j]
        private static void Exch(string[] a, int i, int j)
        {
            string temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        // is v less than w, starting at character d
        private static bool Less(string v, string w, int d)
        {
            // assert v.substring(0, d).equals(w.substring(0, d));
            for (int i = d; i < Math.Min(v.Length, w.Length); i++)
            {
                if (CharAt(v, i) < CharAt(w, i)) return true;
                if (CharAt(v, i) > CharAt(w, i)) return false;
            }
            return v.Length < w.Length;
        }

        //We will use CharAt method to get the int value of a character (ASCII) or -1 if we have finished end of line
        private static int CharAt(string s, int d)
        {
            if (d == s.Length)
            {
                return -1;
            }

            return s[d];
        }
    }
}
