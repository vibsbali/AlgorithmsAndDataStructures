using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;

namespace FundamentalDataStructures
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
         
        public int Count { get; private set; }

        public void Enqueue(T value)
        {
            var node = new Node<T>(value);
            if (tail == null)
            {
                tail = node;
                head = tail;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
                tail = node;
            }

            Count++;
        }

        public void Push(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value);
                tail = head;
            }
            else
            {
                var node = new Node<T>(value)
                {
                    Next = head
                };
                head.Previous = node;
                head = node;
            }
            Count++;
        }

        public T Pop()
        {
            var value = head.Value;
            if (head.Next != null)
            {
                head = head.Next;
            }
            
            head.Previous = null;
            Count--;

            return value;
        }

        public T Dequeue()
        {
            return Pop();
            //var value = tail.Value;
            //if (tail.Previous != null)
            //{
            //    tail = tail.Previous;
            //}
            
            //tail.Next = null;
            //Count--;

            //return value;
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
