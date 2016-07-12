namespace FundamentalDataStructures
{
    public class UnionFindQuick
    {
        private readonly int[] backingArray;

        public UnionFindQuick(int size)
        {
            backingArray = new int[size];
            for (int i = 0; i < backingArray.Length; i++)
            {
                backingArray[i] = i;
            }
        }

        private int FindRoot(int input)
        {
            while (input != backingArray[input])
            {
                input = backingArray[input];
            }

            return input;
        }

        //Find the root of second element and make root of the first element the child of it
        public string Connect(int v1, int v2)
        {
            var rootForFirstElement = FindRoot(v1);
            var rootForSecondElement = FindRoot(v2);
            

            if (rootForFirstElement == rootForSecondElement)
            {
                return "Already Connected";
            }

            backingArray[rootForFirstElement] = rootForSecondElement;
            return "Connected";
        }
    }
}
