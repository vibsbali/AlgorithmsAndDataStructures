namespace Sorting
{
    public class BottomUpMergeSort
    {
        public void Sort(int[] a)
        {
            int[] temp = new int[a.Length];
            for (var size = 1; size < a.Length; size = 2 * size)
            {
                for (int lo = 0; lo < a.Length; lo = lo + 2 * size)
                {
                    int start = lo;
                    int mid = lo + (size - 1);

                    if (mid >= a.Length)
                    {
                        mid = a.Length - 1;
                    }

                    int end = lo + ((2 * size) - 1);

                    if (end >= a.Length)
                    {
                        end = a.Length - 1;
                    }

                    Merge(a, start, mid, end, temp);
                }
                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = temp[i];
                }
            }
        }

        private void Merge(int[] a, int start, int mid, int end, int[] temp)
        {
            int i = start, j = mid + 1, k = start;
            while ((i <= mid) && (j <= end))
            {
                if (a[i] <= a[j])
                {
                    temp[k] = a[i];
                    i++;
                }
                else
                {
                    temp[k] = a[j];
                    j++;
                }
                k++;
            }
            while (i <= mid)
            {
                temp[k] = a[i];
                i++;
                k++;
            }
            while (j <= end)
            {
                temp[k] = a[j];
                j++;
                k++;
            }
        }
    }
}
