using System.Collections.Generic;

namespace Graphs
{
    public class KosarajuSCC
    {
        private readonly bool[] marked;
        public int Count { get; }
        private readonly int[] idsOfStronglyConnectedComponents;

        public KosarajuSCC(DirectedGraph graph)
        {
            marked = new bool[graph.NumberOfVertices];
            idsOfStronglyConnectedComponents = new int[graph.NumberOfVertices];

            DfsVertexOrdering order = new DfsVertexOrdering(graph.Reverse());

            foreach (var s in order.ReversePostOrder())
            {
                if (!marked[s])
                {
                    Dfs(graph, s);
                    Count++;
                }
            }
        }

        private void Dfs(DirectedGraph graph, int sourceVertex)
        {
            marked[sourceVertex] = true;
            idsOfStronglyConnectedComponents[sourceVertex] = Count;

            foreach (var w in graph.GetAdjacencyVertices(sourceVertex))
            {
                if (!marked[w])
                {
                    Dfs(graph, w);
                }
            }
        }

        public bool IsConnected(int sourceVertex, int w)
        {
            return idsOfStronglyConnectedComponents[sourceVertex] == idsOfStronglyConnectedComponents[w];
        }

        public int GetStronglyConnectedComponentId(int vertex)
        {
            return idsOfStronglyConnectedComponents[vertex];
        }

        public Dictionary<int, List<int>> GetGroups()
        {
            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i < Count; i++)
            {
                dict.Add(i, new List<int>());
                for (int j = 0; j < idsOfStronglyConnectedComponents.Length; j++)
                {
                    if (idsOfStronglyConnectedComponents[j] == i)
                    {
                        dict[i].Add(j);
                    }
                }
            }

            return dict;
        } 
    }
}
