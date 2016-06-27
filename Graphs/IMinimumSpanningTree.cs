using System.Collections.Generic;

namespace Graphs
{
    interface IMinimumSpanningTree
    {
        IEnumerable<Edge> GetEdges();
        double TotalWeight();
    }
}
