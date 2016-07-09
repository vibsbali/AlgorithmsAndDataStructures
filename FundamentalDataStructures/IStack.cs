using System.Collections.Generic;
using System.ComponentModel;

namespace FundamentalDataStructures
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IStack<T> : IEnumerable<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
    }
}