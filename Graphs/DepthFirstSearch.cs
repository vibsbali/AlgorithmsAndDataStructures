using System;

namespace Graphs
{
    public class DepthFirstSearch<T>
    {
        private readonly UndirectedGraph<T> graph;
        private readonly int sourceVertex;

        public DepthFirstSearch(UndirectedGraph<T> graph, int sourceVertex)
        {
            this.graph = graph;
            this.sourceVertex = sourceVertex;
        }

        /// <summary>
        /// Is Vertex Connected to source vertex?
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public bool Marked(int vertex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// How many vertices are connected to source vertex
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            throw new NotImplementedException();
        }
    }
}
