using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public class UndirectedGraph<T>
    {
        //Number of Vertices is required to initialise the size of an array for insertion
        //We could use dynamic array which will reduce the need of knowing size of graph in advance
        public int NumberOfVertices { get; }
        public int NumberOfEdges { get; private set; }

        //We can also use List<T,LinkedList<TV>> instead of array
        private readonly Bag<T>[] adjencyArray;

        public UndirectedGraph(int numberOfVertices)
        {
            NumberOfVertices = numberOfVertices;
            adjencyArray = new Bag<T>[NumberOfVertices];

            for (int i = 0; i < numberOfVertices; i++)
            {
                adjencyArray[i] = new Bag<T>();
            }
        }

        public void AddEdge(Vertex<T> firstVertex, Vertex<T> connectingVertex)
        {
            var indexOfFirstVertex = firstVertex.Index;
            var indexOfConnectingVertex = connectingVertex.Index;

            adjencyArray[indexOfFirstVertex].Add(connectingVertex.Value);
            adjencyArray[indexOfConnectingVertex].Add(firstVertex.Value);

            NumberOfEdges++;
        }

        
        public IEnumerable<T> GetAdjencyVertices(int vertexIndex)
        {
            if (vertexIndex > NumberOfVertices || vertexIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            return adjencyArray[vertexIndex].Items;
        }

        public IEnumerable<T> GetAdjencyVertices(Vertex<T> vertex)
        {
            return GetAdjencyVertices(vertex.Index);
        }

        /// <summary>
        /// string representation of the graph's adjacency lists
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append(NumberOfVertices + " vertices, " + NumberOfEdges + " edges" + "\n");

            for (int i = 0; i < NumberOfVertices; i++)
            {
                s.Append(i + ": ");
                foreach (var w in GetAdjencyVertices(i))
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
