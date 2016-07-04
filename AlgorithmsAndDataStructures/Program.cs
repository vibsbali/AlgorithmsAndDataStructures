using System;
using StringSortingAlgorithms;

namespace AlgorithmsAndDataStructures
{
    class Program
    {
        static void Main()
        {
            #region GraphClientCode
            #region Undirected Graph
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
            #endregion

            #region Directed Graph
            //var graph = new DirectedGraph(13);

            //var arrayOfVs = new[] { 4, 2, 3, 6, 0, 2, 11, 12, 9, 9, 8, 10, 11, 4, 3, 7, 8, 5, 0, 6, 6, 7 };
            //var arrayOfWs = new[] { 2, 3, 2, 0, 1, 0, 12, 9, 10, 11, 9, 12, 4, 3, 5, 8, 7, 4, 5, 4, 9, 6 };

            //var graph = new DirectedGraph(7);

            //var arrayOfVs = new[] { 0, 0, 3, 5, 6, 1, 0, 3, 3, 6, 3 };
            //var arrayOfWs = new[] { 5, 1, 5, 2, 0, 4, 2, 6, 4, 4, 2 };


            //for (int i = 0; i < arrayOfVs.Length; i++)
            //{
            //    graph.AddEdge(arrayOfVs[i], arrayOfWs[i]);
            //}


            //Console.WriteLine(graph);

            //var dfs = new DirectedCycle(graph);

            //if (dfs.HasCycle())
            //{
            //    Console.WriteLine(dfs.HasCycle());
            //    foreach (var path in dfs.RetrieveCycle())
            //    {
            //        Console.Write(path + " -> ");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Graph is a DAG");

            //    var dfsVertexOrdering = new DfsVertexOrdering(graph);

            //    Console.WriteLine("\nPrinting Pre Order");
            //    foreach (var df in dfsVertexOrdering.PreOrder())
            //    {
            //        Console.Write(df);
            //    }
            //    Console.WriteLine("\nPrinting Post Order");
            //    foreach (var df in dfsVertexOrdering.PostOrder())
            //    {
            //        Console.Write(df);
            //    }
            //    Console.WriteLine("\nPrinting Reverse Post Order");
            //    foreach (var df in dfsVertexOrdering.ReversePostOrder())
            //    {
            //        Console.Write(df);
            //    }
            //}
            #endregion

            #region KosarajuSCC
            // var graph = new DirectedGraph(13);

            // var arrayOfVs = new[] { 4, 2, 3, 6, 0, 2, 11, 12, 9, 9, 8, 10, 11, 4, 3, 7, 8, 5, 0, 6, 6, 7 };
            // var arrayOfWs = new[] { 2, 3, 2, 0, 1, 0, 12, 9, 10, 11, 9, 12, 4, 3, 5, 8, 7, 4, 5, 4, 9, 6 };


            // for (int i = 0; i < arrayOfVs.Length; i++)
            // {
            //     graph.AddEdge(arrayOfVs[i], arrayOfWs[i]);
            // }

            //var kcc = new KosarajuSCC(graph);
            // Console.WriteLine(kcc.Count);

            // foreach (var @group in kcc.GetGroups())
            // {
            //     Console.Write("Items in group " + @group.Key + " : ");
            //     foreach (var i in @group.Value)
            //     {
            //         Console.Write(i + ",");
            //     }
            //     Console.WriteLine();
            // }
            #endregion

            #region MST
            //var graph = new EdgeWeightedGraph(8);
            //graph.AddEdge(new Edge(0, 7, .16));
            //graph.AddEdge(new Edge(1, 7, .19));
            //graph.AddEdge(new Edge(0, 2, .26));
            //graph.AddEdge(new Edge(2, 3, .17));
            //graph.AddEdge(new Edge(5, 7, .28));
            //graph.AddEdge(new Edge(4, 5, .35));
            //graph.AddEdge(new Edge(6, 2, .40));

            //var mst = new KruskalMST(graph);
            //foreach (var edge in mst.GetEdges())
            //{
            //    Console.WriteLine(edge);
            //}
            //Console.WriteLine("Total Weight :" + mst.TotalWeight());
            #endregion
            #endregion

            #region StringSortingClientCode
            #region LSDSearch

            //var originalStrings = new[] { "4abcd", "5cada", "2edfd", "4caga", "42342", "42342", "32adfd", "12311", "12abcd", "ax25hp", "jk23aj" };

            //var lsdSort = new LSDSort(originalStrings);
            //lsdSort.SortString();
            //foreach (var originalString in originalStrings)
            //{
            //    Console.WriteLine(originalString);
            //}
            
            #endregion

            var sampleString = new[]
            {
                "are", "by", "sea", "seashells", "seashells", "sells", "sells", "she", "she", "shells", "shore", "surely",
                "the", "the"
            };

            var msd = new MSDSort(sampleString);
            msd.SortString();

            foreach (var s in sampleString)
            {
                Console.WriteLine(s);
            }


            #endregion
        }
    }
}
