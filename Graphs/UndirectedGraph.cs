using System;
using System.Collections.Generic;

namespace Graphs
{
    public class UndirectedGraph<T>
    {
        public int NumberOfVertices { get; private set; }
        public int NumberOfEdges { get; private set; }

        private List<Vertex<T>> AdjencyList { get; set; }

        public UndirectedGraph(int numberOfVertices)
        {
            AdjencyList = new List<Vertex<T>>(numberOfVertices);
        }

        public void AddEdge(Vertex<T> firstVertex, Vertex<T> connectingVertex)
        {
            
        }

        public IEnumerable<Vertex<T>> GetAdjencyVertices(int vertex)
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
    }
}
