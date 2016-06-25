namespace Graphs
{
    public class ConnectedComponents
    {
        private readonly bool[] marked;
        private readonly int count;
        private readonly int[] idsOfConnectedComponents;

        public ConnectedComponents(UndirectedGraph<int> graph)
        {
            marked = new bool[graph.NumberOfVertices];
            idsOfConnectedComponents = new int[graph.NumberOfVertices];

            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                   //if vertex is not marked -- then use dfs to search through all the connected vertices
                if (!marked[i])
                {
                    Dfs(graph, i);
                    count++;
                }
            }
        }

        private void Dfs(UndirectedGraph<int> graph, int sourceVertex)
        {
            marked[sourceVertex] = true;
            idsOfConnectedComponents[sourceVertex] = count;

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
            return idsOfConnectedComponents[sourceVertex] == idsOfConnectedComponents[w];
        }

        public int GetConnectedComponentId(int vertex)
        {
            return idsOfConnectedComponents[vertex];
        }
    }
}
