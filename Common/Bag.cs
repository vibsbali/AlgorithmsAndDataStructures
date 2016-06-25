using System;
using System.Collections;
using System.Collections.Generic;

namespace Common
{
    public class Bag<T> : IEnumerable<T>
    {
        private Node<T> head;    // beginning of bag
        private int count;               // number of elements in bag

        // helper linked list class
        private class Node<T>
        {
            internal T Value;
            internal Node<T> Next;
        }


        /**
         * Returns true if this bag is empty.
         *
         * @return <tt>true</tt> if this bag is empty;
         *         <tt>false</tt> otherwise
         */
        public bool IsEmpty()
        {
            return head == null;
        }

        /**
         * Returns the number of items in this bag.
         *
         * @return the number of items in this bag
         */
        public int Size()
        {
            return count;
        }

        /**
         * Adds the item to this bag.
         *
         * @param  item the item to add to this bag
         */
        public void Add(T item)
        {
            Node<T> oldfirst = head;
            head = new Node<T>
            {
                Value = item,
                Next = oldfirst
            };

            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
