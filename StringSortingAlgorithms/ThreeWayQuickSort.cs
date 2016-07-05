using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringSortingAlgorithms
{
    public class ThreeWayQuickSort
    {
        public ThreeWayQuickSort(string[] a)
        {
            Sort(a, 0, a.Length - 1, 0);
        }

        //Uses a three way partioning methodology using digitToSortOn as character element
        //columnToSortOn is an alias for dth character or digitToSortOn
        private void Sort(string[] a, int firstIndex, int lastIndex, int columnToSortOn)
        {
            //This check will unwind the recursion stack and is the terminating statement for recursion
            if (lastIndex <= firstIndex) 
            {
                return;
            }

            //We will get ascii value of d'th character of the very first item in the array / group (left, middle, right) 
            //this will act as a pivot value
            int asciiValue = CharAt(a[firstIndex], columnToSortOn);

            //Once we have the ascii of very first item, we pick the next item for comparison i.e. firstIndex + 1 
            int i = firstIndex + 1;
            int leftPartioningIndex = firstIndex;
            int rightPartioningIndex = lastIndex;

            while (i <= lastIndex) //We screen through item begining with firstIndex + 1 to lastIndex of subarray
            {
                int t = CharAt(a[i], columnToSortOn);

                if (t < asciiValue) //asciiValue is constant we are comparing items in subarray with first item - asciiValue is the pivot
                {
                    Exchange(a, leftPartioningIndex, i++);
                    leftPartioningIndex++;
                }
                else if (t > asciiValue) //asciiValue is constant we are comparing items in subarray with first item
                {
                    Exchange(a, i, rightPartioningIndex);
                    rightPartioningIndex--;
                }

                i++;
            }

            //Sort 3 subarrays recursively
            Sort(a, firstIndex, leftPartioningIndex - 1, columnToSortOn);

            if (asciiValue >= 0)
            {
                Sort(a, leftPartioningIndex, rightPartioningIndex, columnToSortOn+1);
            }

            Sort(a, rightPartioningIndex + 1, lastIndex, columnToSortOn);
        }

        //Method to exchange string from one index to another
        private void Exchange(string[] a, int i, int j)
        {
            string temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        //We will use CharAt method to get the int value of a character(ASCII) or -1 if we have finished end of line
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
