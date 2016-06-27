using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class UnionFind
    {
        private int[] id; // access to component id (site indexed)
        private int count; // number of components

        public UnionFind(int N)
        { // Initialize component id array.
            count = N;
            id = new int[N];
            for (int i = 0; i < N; i++)
                id[i] = i;
        }

        public int Count()
        {
            return count;

        }

        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        public int Find(int p)
        {
            return id[p];
        }

        public void Union(int p, int q)
        {
            // Put p and q into the same component.
            int pID = Find(p);
            int qID = Find(q);
            // Nothing to do if p and q are already in the same component.
            if (pID == qID) return;

            // Rename p’s component to q’s name.
            for (int i = 0; i < id.Length; i++)
                if (id[i] == pID) id[i] = qID;
            count--;
        }
    }
}
