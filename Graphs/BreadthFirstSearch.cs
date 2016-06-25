using System.Collections.Generic;

namespace Graphs
{
    public class BreadthFirstSearch
    {
        private bool[] marked;
        private int[] edgeTo;

        private Queue<int> backingQueue;

        private readonly int sourceVertex;
        private readonly UndirectedGraph<int> graph;

        public BreadthFirstSearch(UndirectedGraph<int> graph, int sourceVertex)
        {
            this.graph = graph;
            this.sourceVertex = sourceVertex;

            marked = new bool[graph.NumberOfVertices];
            edgeTo = new int[graph.NumberOfVertices];

            Bfs();
        }

        private void Bfs()
        {
            backingQueue = new Queue<int>();

            //Step 1. We mark the source vertex as marked and enqueue to our backingQueue
            marked[sourceVertex] = true;
            backingQueue.Enqueue(sourceVertex);

            //Step 2. Run loop while there are any items in the queue
            while (backingQueue.Count > 0)
            {
                //deque the vertex
                var currentVertex = backingQueue.Dequeue();

                //Step 3. Get list of adjacent vertices 
                foreach (var vertex in graph.GetAdjacencyVertices(currentVertex))
                {
                    //Step 4. For each of unmarked adjacent vertex check if it is visited
                    if (!marked[vertex])
                    {
                        //Step 5. If it is the first time we are visiting it then, mark visited and add to edgeTo array
                        edgeTo[vertex] = currentVertex;
                        marked[vertex] = true; 
                        backingQueue.Enqueue(vertex);
                    }
                }
            }
        }


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
    }
}
