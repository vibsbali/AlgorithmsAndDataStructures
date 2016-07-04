namespace StringSortingAlgorithms
{
    // ReSharper disable once InconsistentNaming
    public class LSDSort
    {
        // ReSharper disable once InconsistentNaming
        private string[] A;

        public LSDSort(string[] a)
        {
            this.A = a;
        }

        public void SortString()
        {
            var length = A.Length;
            var radix = 256; //extended ASCII alphabet size
            

            var dimension = A[0].Length;
            var aux = new string[length];

            for (int d = dimension - 1; d >= 0; d--)
            {
                var count = new int[radix + 1];
                //Step 1 for each string in stringArray find the char that exists at index = dimension and
                //add one to it i.e. if 0 then it would be 1 and so forth
                //finally increment the count
                for (int j = 0; j < length; j++)
                {
                    var charValue = A[j][d];
                    count[charValue + 1]++;
                }    

                //Step 2 for each value in count array update the values by creating a frequency table i.e. cumulative running total
                for (int j = 0; j < radix; j++)
                {
                    count[j + 1] += count[j];
                }

                //Step 3 update aux table
                for (int j = 0; j < length; j++)    //Go through all the strings inside string array
                {
                    var existingIndexOfCharInCountArray = count[A[j][d]];
                    aux[existingIndexOfCharInCountArray] = A[j];
                    count[A[j][d]] += 1;    //Increment the exisiting value in cumulative running total by 1
                }

                //step 3 copy the values from aux to original array
                for (int j = 0; j < length; j++)
                {
                    A[j] = aux[j];
                }
            }
        }
    }
}
