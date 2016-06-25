using System;
using Graphs;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            var graph = new UndirectedGraph<int>(13);

            graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(5, 5));
            graph.AddEdge(new Vertex<int>(4, 4), new Vertex<int>(3, 3));
            graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(1, 1));
            graph.AddEdge(new Vertex<int>(9, 9), new Vertex<int>(12, 12));
            graph.AddEdge(new Vertex<int>(6, 6), new Vertex<int>(4, 4));
            graph.AddEdge(new Vertex<int>(5, 5), new Vertex<int>(4, 4));
            graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(2, 2));
            graph.AddEdge(new Vertex<int>(11, 11), new Vertex<int>(12, 12));
            graph.AddEdge(new Vertex<int>(9, 9), new Vertex<int>(10, 10));
            graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(6, 6));
            graph.AddEdge(new Vertex<int>(7, 7), new Vertex<int>(8, 8));
            graph.AddEdge(new Vertex<int>(9, 9), new Vertex<int>(11, 11));
            graph.AddEdge(new Vertex<int>(5, 5), new Vertex<int>(3, 3));
        }
    }
}
