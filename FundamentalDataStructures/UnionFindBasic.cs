namespace FundamentalDataStructures
{
    public class UnionFindBasic
    {
        private readonly int[] backingArray;

        public UnionFindBasic(int size)
        {
            backingArray = new int[size];
            //initalize with basic values
            for (int i = 0; i < backingArray.Length; i++)
            {
                backingArray[i] = i;
            }
        }

        public bool Connect(int v1, int v2)
        {
            //check if already connected
            if (!IsConnected(v1, v2))
            {
                var valueOfV2 = backingArray[v2];
                var valueOfV1 = backingArray[v1];

                for (int i = 0; i < backingArray.Length; i++)
                {
                    if (backingArray[i] == valueOfV1)
                    {
                        backingArray[i] = valueOfV2;
                    }
                }

                return true;
            }

            return false;
        }

        public bool IsConnected(int v1, int v2)
        {
            return backingArray[v1] == backingArray[v2];
        }
    }
}
