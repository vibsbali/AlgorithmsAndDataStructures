﻿using System.Collections.Generic;

namespace Graphs
{
    public class DepthFirstSearch
    {
        private bool[] marked;
        private int count;

        private int[] edgeTo;
        private readonly int sourceVertex;

        #region Constructors for Directed Graph
        //Directed Graph Search
        public DepthFirstSearch(DirectedGraph graph, int sourceVertex)
        {
            edgeTo = new int[graph.NumberOfVertices];
            marked = new bool[graph.NumberOfVertices];

            this.sourceVertex = sourceVertex;
            Dfs(graph, sourceVertex);
        }

        private void Dfs(DirectedGraph graph, int vertexBeingVisted)
        {
            marked[vertexBeingVisted] = true;
            foreach (var adjacentVertex in graph.GetAdjacencyVertices(vertexBeingVisted))
            {
                count++;
                if (!marked[adjacentVertex])
                {
                    edgeTo[adjacentVertex] = vertexBeingVisted;
                    Dfs(graph, adjacentVertex);
                }
            }
        }
        #endregion

        #region Constructors for Undirected Graph
        //Undirected Graph Search
        public DepthFirstSearch(UndirectedGraph<int> graph, int sourceVertex)
        {
            edgeTo = new int[graph.NumberOfVertices];
            marked = new bool[graph.NumberOfVertices];

            this.sourceVertex = sourceVertex;
            Dfs(graph, sourceVertex);
        }

        private void Dfs(UndirectedGraph<int> graph, int vertexBeingVisted)
        {
            marked[vertexBeingVisted] = true;
            foreach (var adjacentVertex in graph.GetAdjacencyVertices(vertexBeingVisted))
            {
                count++;
                if (!marked[adjacentVertex])
                {
                    edgeTo[adjacentVertex] = vertexBeingVisted;
                    Dfs(graph, adjacentVertex);
                }
            }
        }
        #endregion

        /// <summary>
        /// Is Vertex Connected to source vertex?
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private bool HasVisted(int vertex)
        {
            return marked[vertex];
        }

        /// <summary>
        /// A wrapper function to check, Is there a path from source vertex to a given vertex v
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool PathExists(int vertex)
        {
            return HasVisted(vertex);
        }

        /// <summary>
        /// This method is not the correct way to find the shortest path.. 
        /// To find shortest path, Breadth First Search is used
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<int> PathTo(int vertex)
        {
            if (PathExists(vertex))
            {
                var path = new Stack<int>();
                int root = vertex;
                do
                {
                    path.Push(root);
                    root = edgeTo[root];
                } while (root != sourceVertex);

                path.Push(sourceVertex);
                return path;
            }

            return null;
        }

        /// <summary>
        /// How many vertices are connected to source vertex
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }
    }
}
