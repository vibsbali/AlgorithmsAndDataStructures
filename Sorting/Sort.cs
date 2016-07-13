using System;
using System.Collections.Generic;

namespace Sorting
{
    public class Sort<T> where T : IComparable<T>
    {
        private readonly T[] arrayToSort;
        private bool swapPerformed = true;

        public Sort(T[] arrayToSort)
        {
            this.arrayToSort = arrayToSort;
        }

        public void Swap(int fromIndex, int toIndex)
        {
            var temp = arrayToSort[toIndex];
            arrayToSort[toIndex] = arrayToSort[fromIndex];
            arrayToSort[fromIndex] = temp;
        }

        //Complexity o(n) if already sorted and o(n^2) is not sorted
        public T[] BubbleSort()
        {
            do
            {
                swapPerformed = false;
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    if (arrayToSort[i].CompareTo(arrayToSort[i + 1]) > 0)
                    {
                        Swap(i, i + 1);
                        swapPerformed = true;
                    }
                }
            } while (swapPerformed);

            return arrayToSort;
        }

        //Find smallest item in the array and exchange it with the first entry.
        //Then find the next smallest item and exchange it with the second entry and so forth
        public T[] SelectionSort()
        {
            for (int i = 0; i < arrayToSort.Length; i++)
            {
                var min = arrayToSort[i];
                for (int j = i + 1; j < arrayToSort.Length; j++)
                {
                    if (arrayToSort[j].CompareTo(min) < 0)
                    {
                        Swap(i, j);
                    }
                }
            }

            return arrayToSort;
        }

        //Insertion sort
        //Think of it as cards in your hand. We sort our cards by comparing 1st with 0 and so forth
        //When we come across a card which is smaller than the previous we move it back to the place where it should be 
        //And in this process we move the cards which are larger 1 step to the right
        public T[] InsertionSort()
        {
            var numberOfComparisons = 0;
            var numberOfExchanges = 0;

            for (int i = 1; i < arrayToSort.Length; i++)
            {
                numberOfComparisons++;
                if (arrayToSort[i].CompareTo(arrayToSort[i - 1]) < 0)
                {
                    var j = i;
                    while (j > 0)
                    {
                        if (arrayToSort[j].CompareTo(arrayToSort[j - 1]) < 0)
                        {
                            numberOfExchanges++;
                            Swap(j, j - 1);
                        }
                        j--;
                    }
                }
            }

            Console.WriteLine("Length of Array " + arrayToSort.Length);
            Console.WriteLine("Number of comparisons " + numberOfComparisons);
            Console.WriteLine("Number of exchangs " + numberOfExchanges);

            return arrayToSort;
        }

        //Shell sort - Useful for large number of elements and random. It makes more comparisons but less exchanges in comparison to insertion sort
        //Think of it as Insertion sort with different step methods. 
        //The algorithm we use to get size of h is 1 4 13 40 i.e. 3x + 1
        //However Sedgewick 1, 5, 19, 41, 109, 209 i.e. merging of (9 x 4^i) - (9 x 2^i) + 1 and 4^i - (3 x 2^i) + 1
        //For our purposes with will stick with 3x + 1
        public T[] ShellSort()
        {
            var numberOfComparisons = 0;
            var numberOfExchanges = 0;

            var gap = 1;
            while (gap < arrayToSort.Length)
            {
                gap = gap * 3 + 1;
            }
            gap = (gap - 1) / 3;

            while (gap >= 1)
            {
                for (int i = gap; i < arrayToSort.Length; i = i + gap)
                {
                    numberOfComparisons++;
                    if (arrayToSort[i].CompareTo(arrayToSort[i - gap]) < 0)
                    {
                        var j = i;
                        while (j > 0)
                        {
                            if (arrayToSort[j].CompareTo(arrayToSort[j - gap]) < 0)
                            {
                                numberOfExchanges++;
                                Swap(j, j - gap);
                            }
                            j = j - gap;
                        }
                    }
                }
                gap = (gap - 1) / 3;
            }

            Console.WriteLine("Length of Array " + arrayToSort.Length);
            Console.WriteLine("Number of comparisons " + numberOfComparisons);
            Console.WriteLine("Number of exchangs " + numberOfExchanges);

            return arrayToSort;
        }

        public T[] MergeSort()
        {
            MSort(arrayToSort);
            return arrayToSort;
        }

        //We divide array into smaller chunks by recursive calls until the length of array is equal to 1
        //As call stack decreases the size of items will increase and eventually it will be equal to the inital array
        //This is a great algorithm to understand what is it that we wanted - We wanted somehow to break an array and then build it together without having to count the number of broken arrays 
        private void MSort(T[] items)
        {
            //This is exit condtion of recursion however the last call of this method will have an array size of 2
            if (items.Length <= 1)
            {
                return;
            }

            //Find Left and Right i.e. Mid
            var left = items.Length / 2;
            var right = items.Length - left;

            //Create Auxilary arrays - this is important
            var leftArray = new T[left];
            var rightArray = new T[right];

            //Copy Values
            Array.Copy(items, 0, leftArray, 0, left);
            Array.Copy(items, left, rightArray, 0, right);

            //Sort Left array
            MSort(leftArray);
            //Sort Right array
            MSort(rightArray);

            //When following method is called the value of items will be an array with minimum length of 2
            Merge(items, leftArray, rightArray);
        }

        private void Merge(T[] items, T[] leftArray, T[] rightArray)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;

            int remaining = leftArray.Length + rightArray.Length;

            while (remaining > 0)
            {
                //check if left array has been exhausted
                if (leftIndex >= leftArray.Length)
                {
                    items[targetIndex] = rightArray[rightIndex++];
                }
                //check if left array has been exhausted
                else if (rightIndex >= rightArray.Length)
                {
                    items[targetIndex] = leftArray[leftIndex++];
                }
                else if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 0)
                {
                    items[targetIndex] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    items[targetIndex] = rightArray[rightIndex];
                    rightIndex++;
                }

                targetIndex++;
                remaining--;
            }

        }
    }
}
