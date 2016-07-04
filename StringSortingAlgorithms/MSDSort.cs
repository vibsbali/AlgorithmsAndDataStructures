/*
1. Partition array into R pieces according to first character
(use key-indexed counting).
2. Recursively sort all strings that start with each character
(key-indexed counts delineate subarrays to sort).
*/



namespace StringSortingAlgorithms
{
    public class MSDSort
    {
        private string[] strings;
        private readonly int lengthOfArray;
        private string[] aux;
        private int Radix = 256;

        public MSDSort(string[] a)
        {
            this.strings = a;
            lengthOfArray = a.Length;
            aux = new string[lengthOfArray];
        }

        public void SortString()
        {
            sort(strings, 0, lengthOfArray - 1, aux, 0);  //Initially we call sort with digit = 0 i.e. sort of first character
        }

        //sort from a[lo] to a[high], starting at the dth character
        private void sort(string[] a, int lo, int high, string[] aux1, int d)
        {
            //create a count array with +2 this time in LSD we had 1
            var count = new int[Radix + 2];

            //create an array of count frequency of each character
            for (int i = lo; i <= high; i++)
            {
                count[ChartAt(a[i], d)]++;
            }

            //create a (cumulative array) i.e transform couts to indices
            for (int i = lo; i < Radix + 1; i++)
            {
                count[i + 1] += count[i];
            }

            //distribute 
            for (int i = lo; i <= high; i++)
            {
                int c = ChartAt(a[i], d);
                aux[count[c]++] = a[i];
            }

            //copy back
            for (int i = lo; i <= high; i++)
            {
                a[i] = aux[i - lo];
            }

            //recursively sort for each character 
            for (int i = 0; i < Radix; i++)
                sort(a, lo + count[i], lo + count[i + 1] - 1, aux, d + 1);

        }


        //We will use CharAt method to get the int value of a character (ASCII) or -1 if we have finished end of line
        private static int ChartAt(string s, int d)
        {
            if (d == s.Length)
            {
                return -1;
            }

            return s[d];
        }
    }
}
