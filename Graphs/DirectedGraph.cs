using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class DirectedGraph
    {
        public int NumberOfVertices { get; private set; }
        public int NumberOfEdges { get; private set; }

        private readonly Bag<int>[] adjacencyArray;


        public DirectedGraph(int numberOfVertices)
        {
            NumberOfVertices = numberOfVertices;
            adjacencyArray = new Bag<int>[NumberOfVertices];        
        }

        public void AddEdge(int v, int w)
        {
            adjacencyArray[v].Items.AddFirst(w);
            NumberOfEdges++;
        }

        public IEnumerable<int> GetAdjacencyVertices(int v)
        {
            return adjacencyArray[v].Items;
        }

        public DirectedGraph Reverse()
        {
            var reversedGraph = new DirectedGraph(NumberOfVertices);
            for (int index = 0; index < adjacencyArray.Length; index++)
            {
                foreach (var ajacentVertex in GetAdjacencyVertices(index))
                {
                    reversedGraph.AddEdge(ajacentVertex, index);
                }
            }

            return reversedGraph;
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append(NumberOfVertices + " vertices, " + NumberOfEdges + " edges" + "\n");

            for (int i = 0; i < NumberOfVertices; i++)
            {
                s.Append(i + ": ");
                foreach (var w in GetAdjacencyVertices(i))
                {
                    s.Append(" " + w + ",");
                }
                s.Append("\n");
            }

            return s.ToString();
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
