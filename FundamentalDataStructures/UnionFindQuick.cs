namespace FundamentalDataStructures
{
    public class UnionFindQuick
    {
        private readonly int[] backingArray;
        private readonly int[] depthArray;

        public UnionFindQuick(int size)
        {
            backingArray = new int[size];
            depthArray = new int[size];
            for (int i = 0; i < backingArray.Length; i++)
            {
                backingArray[i] = i;
                depthArray[i] = 1;
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

            //backingArray[rootForFirstElement] = rootForSecondElement;
            //OR following code with if/else statments
            //Make smaller root point to larger one
            if (depthArray[rootForFirstElement] < depthArray[rootForSecondElement])
            {
                backingArray[rootForFirstElement] = rootForSecondElement;
                depthArray[rootForSecondElement] += depthArray[rootForFirstElement];
            }
            else
            {
                backingArray[rootForSecondElement] = rootForFirstElement;
                depthArray[rootForFirstElement] += depthArray[rootForSecondElement];
            }

            
            return "Connected";
        }
    }
}
