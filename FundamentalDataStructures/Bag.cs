using System;
using System.Collections;
using System.Collections.Generic;

namespace FundamentalDataStructures
{
    public class Bag<T> : IEnumerable<T>
    {
        private Node<T> head; 
        public int Count { get; private set; }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Add(T item)
        {
            var currentHead = head;
            head = new Node<T>(item)
            {
                Next = currentHead
            };
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
