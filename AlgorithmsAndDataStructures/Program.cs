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

            //var graph = new UndirectedGraph<int>(6);
            //graph.AddEdge(new Vertex<int>(0,0), new Vertex<int>(5, 5));
            //graph.AddEdge(new Vertex<int>(2, 2), new Vertex<int>(4, 4));
            //graph.AddEdge(new Vertex<int>(2, 2), new Vertex<int>(3, 3));
            //graph.AddEdge(new Vertex<int>(1, 1), new Vertex<int>(2, 2));
            //graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(1, 1));
            //graph.AddEdge(new Vertex<int>(3, 3), new Vertex<int>(4, 4));
            //graph.AddEdge(new Vertex<int>(3, 3), new Vertex<int>(5, 5));
            //graph.AddEdge(new Vertex<int>(0, 0), new Vertex<int>(2, 2));

            var graph = new DirectedGraph(13);

            var arrayOfVs = new[] {4, 2, 3, 6, 0, 2, 11, 12, 9, 9, 8, 10, 11, 4, 3, 7, 8, 5, 0, 6, 6, 7};
            var arrayOfWs = new[] {2, 3, 2, 0, 1, 0, 12, 9, 10, 11, 9, 12, 4, 3, 5, 8, 7, 4, 5, 4, 9, 6};

            for (int i = 0; i < arrayOfVs.Length; i++)
            {
                graph.AddEdge(arrayOfVs[i], arrayOfWs[i]);
            }


            Console.WriteLine(graph);

            var dfs = new DirectedCycle(graph);

            var w = 9;

            Console.WriteLine(dfs.HasCycle());
            if (dfs.HasCycle())
            {
                foreach (var path in dfs.RetrieveCycle())
                {
                    Console.Write(path + " -> ");
                }
            }
            
        }
    }
}
