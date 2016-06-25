using System;
using System.Collections.Generic;

namespace Graphs
{
    public class UndirectedGraph<T>
    {
        //Number of Vertices is required to initialise the size of an array for insertion
        //We could use dynamic array which will reduce the need of knowing size of graph in advance
        public int NumberOfVertices { get; }
        public int NumberOfEdges { get; private set; }

        //We can also use List<T,List<TV>> instead of array
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

        public IEnumerable<Vertex<T>> GetAdjencyVertices(int vertexIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vertex<T>> GetAdjencyVertices(Vertex<T> vertex)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Helper class for implementing AdjencyList
        /// Instead of creating a bag class we can implement List<T,List<TV>>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        internal class Bag<T>
        {
            internal List<T> items;

            public Bag()
            {
                items = new List<T>();
            }

            internal void Add(T value)
            {
                items.Add(value);
            }
        }
    }
}
