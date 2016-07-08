using System.Collections;
using System.Collections.Generic;

namespace FundamentalDataStructures
{
    public class Stack<T> : IStack<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Push(T item)
        {
            throw new System.NotImplementedException();
        }

        public T Pop()
        {
            throw new System.NotImplementedException();
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new System.NotImplementedException();
        }
    }
}
