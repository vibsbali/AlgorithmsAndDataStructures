using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class KruskalMST : IMinimumSpanningTree
    {
        private Queue<Edge> minimumSpanningTree;
        public KruskalMST(EdgeWeightedGraph graph)
        {
            minimumSpanningTree = new Queue<Edge>();
            var priorityQueue = new SortedSet<Edge>(); //Using SortedSet<T> instead of priority queue
            var uf = new UnionFind(graph.NumberOfVertices);

            foreach (var edge in graph.Edges())
            {
                priorityQueue.Add(edge);
            }

            while (priorityQueue.Count > 0 && minimumSpanningTree.Count < graph.NumberOfVertices - 1)
            {
                //Get the minimum weighted edge and remove it from the priority queue
                var edge = priorityQueue.Min;
                priorityQueue.Remove(edge);

                //Get both vertices
                int v = edge.Either();
                int w = edge.Other(v);

                if (uf.IsConnected(v, w))
                {
                    continue;
                }
                uf.Union(v, w);
                minimumSpanningTree.Enqueue(edge);
            }
        }


        public IEnumerable<Edge> GetEdges()
        {
            return minimumSpanningTree;
        }

        public double TotalWeight()
        {
            var temp = 0.0;
            foreach (var edge in minimumSpanningTree)
            {
                temp += edge.Weight;
            }

            return temp;
        }
    }
}
