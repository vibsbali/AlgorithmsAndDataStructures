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
        private void Sort(string[] a, int firstIndex, int lastIndex, int d)
        {
            //This check will unwind the recursion stack and is the terminating statement for recursion
            if (lastIndex <= firstIndex) 
            {
                return;
            }

            int lt = firstIndex, gt = lastIndex;

            int v = CharAt(a[firstIndex], d);
            int i = firstIndex + 1;
            while (i <= gt)
            {
                int t = CharAt(a[i], d);
                if (t < v)
                {
                    Exchange(a, lt, i);  //i is only updated when t < v or where t == v
                    lt++;
                    i++;
                }
                else if (t > v)
                {
                    Exchange(a, i, gt);
                    gt--;
                }
                else
                {
                    i++;
                }
            }

            // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]. 
            Sort(a, firstIndex, lt - 1, d);

            if (v >= 0)
            {
                Sort(a, lt, gt, d + 1);
            }

            Sort(a, gt + 1, lastIndex, d);
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
