using System;
using Graphs;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static void Main()
        {
            //var graph = new UndirectedGraph<int>(13);

            //graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(5, 5));
            //graph.AddEdge(new Vertex<int>(4, 4), new Vertex<int>(3, 3));
            //graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(1, 1));
            //graph.AddEdge(new Vertex<int>(9, 9), new Vertex<int>(12, 12));
            //graph.AddEdge(new Vertex<int>(6, 6), new Vertex<int>(4, 4));
            //graph.AddEdge(new Vertex<int>(5, 5), new Vertex<int>(4, 4));
            //graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(2, 2));
            //graph.AddEdge(new Vertex<int>(11, 11), new Vertex<int>(12, 12));
            //graph.AddEdge(new Vertex<int>(9, 9), new Vertex<int>(10, 10));
            //graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(6, 6));
            //graph.AddEdge(new Vertex<int>(7, 7), new Vertex<int>(8, 8));
            //graph.AddEdge(new Vertex<int>(9, 9), new Vertex<int>(11, 11));
            //graph.AddEdge(new Vertex<int>(5, 5), new Vertex<int>(3, 3));

            var graph = new UndirectedGraph<int>(6);
            graph.AddEdge(new Vertex<int>(0,0), new Vertex<int>(5, 5));
            graph.AddEdge(new Vertex<int>(2, 2), new Vertex<int>(4, 4));
            graph.AddEdge(new Vertex<int>(2, 2), new Vertex<int>(3, 3));
            graph.AddEdge(new Vertex<int>(1, 1), new Vertex<int>(2, 2));
            graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(1, 1));
            graph.AddEdge(new Vertex<int>(3, 3), new Vertex<int>(4, 4));
            graph.AddEdge(new Vertex<int>(3, 3), new Vertex<int>(5, 5));
            graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(2, 2));

            Console.WriteLine(graph);

            var dfs = new DepthFirstSearch(graph, 0);
            
            Console.WriteLine(dfs.Count());
            Console.WriteLine(dfs.PathExists(5));

            foreach (var i in dfs.PathTo(0))
            {
                Console.Write(i + " -> ");
            }
        }
    }
}
