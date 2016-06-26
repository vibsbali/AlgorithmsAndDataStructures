using System.Collections;
using System.Collections.Generic;

namespace Graphs
{
    public class DirectedCycle
    {
        private bool[] onStack;
        private int[] edgeTo;
        private bool[] marked;
        private Stack<int> cycle;

        public DirectedCycle(DirectedGraph graph)
        {
            onStack = new bool[graph.NumberOfVertices];
            edgeTo = new int[graph.NumberOfVertices];
            marked = new bool[graph.NumberOfVertices];

            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                if (!marked[i])
                {
                    Dfs(graph, i);
                }
            }
        }

        private void Dfs(DirectedGraph graph, int sourceVertex)
        {
            onStack[sourceVertex] = true;
            marked[sourceVertex] = true;

            foreach (var w in graph.GetAdjacencyVertices(sourceVertex))
            {
                if (this.HasCycle())
                {
                    return;
                }
                if(!marked[w])
                {
                    edgeTo[w] = sourceVertex;
                    Dfs(graph, w);
                }
                else if (onStack[w])
                {
                    cycle = new Stack<int>();
                    for (int i = sourceVertex; i != w; i = edgeTo[i])
                    {
                        cycle.Push(i);
                    }    
                    cycle.Push(w);
                    cycle.Push(sourceVertex);
                }
            }
            onStack[sourceVertex] = false;
        }

        public bool HasCycle()
        {
            return cycle != null;
        }

        public IEnumerable<int> RetrieveCycle()
        {
            return cycle;
        } 
    }
}
