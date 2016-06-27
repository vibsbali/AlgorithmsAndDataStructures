/*
* This ADT will be used for 
*
*/
using System;

namespace Graphs
{
    public class Edge : IComparable<Edge>
    {
        private int v;
        private int w;
        public double Weight { get;  }

        public Edge(int v, int w, double weight)
        {
            this.v = v;
            this.w = w;
            Weight = weight;
        }

        public int Either()
        {
            return v;
        }

        public int Other(int vertex)
        {
            if (vertex == v)
            {
                return w;
            }
            if (vertex == w)
            {
                return v;
            }

            throw new ArgumentException("Invalid Vertex for edge");
        }

        public int CompareTo(Edge other)
        {
            if (Weight > other.Weight)
            {
                return 1;
            }
            if (Weight < other.Weight)
            {
                return -1;
            }
            return 0;
        }

        public override string ToString()
        {
            return $"{v}-{w} {Weight}";
        }
    }
}
