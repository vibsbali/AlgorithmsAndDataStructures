using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class EdgeWeightedGraph
    {
        public int NumberOfVertices { get; }
        public int NumberOfEdges { get; private set; }
        private readonly Bag<Edge>[] adjacentList; 

        public EdgeWeightedGraph(int v)
        {
            NumberOfVertices = v;
            adjacentList = new Bag<Edge>[NumberOfVertices];
            for (int i = 0; i < v; i++)
            {
                adjacentList[i] = new Bag<Edge>();
            }
        }

        public void AddEdge(Edge edge)
        {
            int v = edge.Either();
            int w = edge.Other(v);

            //Since it is an undirected graph we need to add reference to edge in both 
            adjacentList[v].Add(edge);
            adjacentList[w].Add(edge);

            NumberOfEdges++;
        }

        public IEnumerable<Edge> GetAdjacentList(int v)
        {
            return adjacentList[v].Items;
        }

        public IEnumerable<Edge> Edges()
        {
            var b = new Bag<Edge>();

            for (int i = 0; i < NumberOfVertices; i++)
            {
                foreach (Edge edge in adjacentList[i].Items)
                {
                    if (edge.Other(i) > i)
                    {
                        b.Add(edge);
                    }
                }
            }

            return b.Items;
        } 


        /// <summary>
        /// Helper class for implementing AdjencyList
#pragma warning disable 1570
        /// Instead of creating a bag class we can implement List<T,LinkedList<TV>>
#pragma warning restore 1570
#pragma warning disable 1570
        /// </summary>
#pragma warning restore 1570
        /// <typeparam name="T"></typeparam>
#pragma warning disable 693
        internal class Bag<T>
#pragma warning restore 693
        {
            internal LinkedList<T> Items;

            public Bag()
            {
                Items = new LinkedList<T>();
            }

            internal void Add(T value)
            {
                Items.AddFirst(value);
            }
        }
    }
}
