namespace Graphs
{
    public class Vertex<T>
    {
        public T Value { get; private set; }
        public int Index { get; private set; }

        public Vertex(int index, T value)
        {
            Index = index;
            Value = value;
        }
    }
}
