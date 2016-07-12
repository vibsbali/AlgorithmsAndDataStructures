using System;

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
            for (int i = 1; i < arrayToSort.Length; i++)
            {
                if (arrayToSort[i].CompareTo(arrayToSort[i - 1]) < 0)
                {
                    var j = i;
                    while (j > 0)
                    {
                        if (arrayToSort[j].CompareTo(arrayToSort[j-1]) < 0)
                        {
                            Swap(j, j-1);
                        }
                        j--;
                    }
                }
            }

            return arrayToSort;
        }
    }
}
