using System;
using System.Collections.Generic;

//Note this is not the proper implementation
namespace FundamentalDataStructures
{
    public class UnionFindWithTree<T> where T : IComparable<T>
    {
        readonly List<HashSet<T>> hashSetTrees = new List<HashSet<T>>();
        private int count;

        public UnionFindWithTree()
        {
            //hashSetTrees.Add(new HashSet<T>());    
        }

        //Complexity 2(M(log(N)) where M = Number of Count i.e. number of trees
        public bool Connect(T v1, T v2)
        {
            var root1 = FindRoot(v1);
            var root2 = FindRoot(v2);

            if (root1 != -1)
            {
                //check if already connected
                if (root1 == root2)
                {
                    return false;
                }

                //This method is an O(n) operation, where n is the number of elements in the other parameter i.e. root2
                //This can be made constant if we were to create our own Binary tree and point head of root2 to point to head of root1
                if (root1 != root2 && root2 != -1)
                {
                    hashSetTrees[root1].UnionWith(hashSetTrees[root2]);
                    hashSetTrees.Remove(hashSetTrees[root2]);
                    count--;

                    return false;
                }
                if (root1 != root2 && root2 == -1)
                {
                    hashSetTrees[root1].Add(v2);
                    return true;
                }
                if (root1 != root2 && root2 != -1)
                {
                    hashSetTrees[root2].Add(v1);
                    return true;
                }
            }

            hashSetTrees.Add(new HashSet<T>());
            count++;
            hashSetTrees[count-1].Add(v1);
            hashSetTrees[count-1].Add(v2);

            

            return true;
        }

        //Complexity 2(M(log(N)) where M = Number of Count i.e. number of trees
        public bool IsConnected(T v1, T v2)
        {
            var root1 = FindRoot(v1);
            var root2 = FindRoot(v2);

            return root1 == root2;
        }

        //FindRoot complexity is M(log(N)) where M = Number of Count i.e. number of trees
        private int FindRoot(T value)
        {
            for (int i = 0; i < count; i++)
            {
                var hashSetTree = hashSetTrees[i];
                if (hashSetTree.Contains(value))
                {
                   return i;
                }
            }

            return -1;
        }
    }
}
