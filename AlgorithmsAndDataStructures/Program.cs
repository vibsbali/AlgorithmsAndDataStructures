using System;
using System.Linq;
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

            //var originalStrings = new[] { "4PGC938","2IYE230","3CIO720","1ICK750","1OHV845","4JZY524", "1ICK750", "3CIO720", "1OHV845", "1OHV845", "2RLA629", "2RLA629", "3ATW723" };
            ////var originalStrings = new[] {"a", "b", "c", "e", "a", "f", "a", "e", "b"};

            //var lsdSort = new LSDSort(originalStrings);
            //lsdSort.SortString();
            //foreach (var originalString in originalStrings)
            //{
            //    Console.WriteLine(originalString);
            //}

            //Console.WriteLine("Finished sorting one");
            //var sortedArray = originalStrings.OrderBy(i => i);
            //foreach (var item in sortedArray)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion
            #region MSD
            //"sea", "seashells",  "sells", 
            //var sampleString = new[]
            //{
            //    "seashells", "by", "are", "sells", "she", "she", "shells", "shore", "surely", "the", "the"
            //};
            //var msd = new MSDSort(sampleString);
            //msd.SortString();

            //foreach (var s in sampleString)
            //{
            //    Console.WriteLine(s);
            //}
            #endregion
            #region ThreeWayQuickSort
            //"sea", "seashells",  "sells", 
            //var sampleString = new[]
            //{
            //    "seashells", "by", "are", "sells", "she", "she", "shells", "shore", "surely", "the", "the"
            //};
            //var threeWayQuickSort = new ThreeWayQuickSort(sampleString);
            //foreach (var s in sampleString)
            //{
            //    Console.WriteLine(s);
            //}
            #endregion

            #region Trie
            var trie = new Trie<int>();
            trie.Put("by", 4);
            trie.Put("sea", 6);
            trie.Put("sells", 1);
            trie.Put("she", 0);
            trie.Put("shells", 3);
            trie.Put("shore", 7);
            trie.Put("the", 5);

            try
            {
                Console.WriteLine(trie.Get("she"));
                Console.WriteLine(trie.Get("se"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            #endregion
            #endregion
        }
    }
}
