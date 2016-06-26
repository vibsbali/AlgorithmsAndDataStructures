using System.Collections.Generic;

namespace Graphs
{
    public class DfsVertexOrdering
    {
        private readonly Queue<int> preOrder;
        private readonly Queue<int> postOrder;
        private readonly Stack<int> reversePost;
        private readonly bool[] marked;

        public DfsVertexOrdering(DirectedGraph graph)
        {
            preOrder = new Queue<int>();
            postOrder = new Queue<int>();
            reversePost = new Stack<int>();

            marked = new bool[graph.NumberOfVertices];

            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                if (!marked[i])
                {
                    Dfs(graph, i);
                }
            }
        }

        public void Dfs(DirectedGraph graph, int v)
        {
            preOrder.Enqueue(v);

            marked[v] = true;
            foreach (var w in graph.GetAdjacencyVertices(v))
            {
                if (!marked[w])
                {
                    Dfs(graph, w);
                }
            }
            postOrder.Enqueue(v);
            reversePost.Push(v);
        }

        public IEnumerable<int> PreOrder()
        {
            return preOrder;
        }

        public IEnumerable<int> PostOrder()
        {
            return postOrder;
        }

        public IEnumerable<int> ReversePostOrder()
        {
            return reversePost;
        }
    }
}
