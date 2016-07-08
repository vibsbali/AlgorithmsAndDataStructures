using System.Collections.Generic;

namespace FundamentalDataStructures
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IQueue<T> : IEnumerable<T>
    {
        void Enqueue(T item);
        T Dequeue();
        int Count();
        bool IsEmpty();
    }
}