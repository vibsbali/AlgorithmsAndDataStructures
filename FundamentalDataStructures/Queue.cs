using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace FundamentalDataStructures
{
    public class Queue<T> : IQueue<T>
    {
        private int Size { get; set; }
        public int Count { get; private set; }
        private T[] Items { get; set; }

        private int head;
        private int tail;

        public Queue(int size)
        {
            Size = size;
            Items = new T[size];
        }

        public Queue() : this(2)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enqueue(T item)
        {
            //Check if any indexes are empty for insertion i.e. wrap or not to wrap
            if (head == Items.Length)
            {
                if (Count < Items.Length && tail > 0)
                {
                    head = 0;
                }
                else
                {
                    Resize();
                }
            }

            Items[head] = item;
            head++;

            Count++;
        }

        private void Resize()
        {
            var temp = new T[Items.Length * 2];
            int delta;

            //using Array.Copy
            if (head < tail)
            {
                var deltaOne = Items.Length - tail;
                Array.Copy(Items, tail, temp, 0, deltaOne);

                var deltaTwo = tail - head;
                Array.Copy(Items, head, temp, deltaOne + 1, deltaTwo);
                delta = deltaOne + deltaTwo;
            }
            else
            {
                delta = head - tail;
                Array.Copy(Items, tail, temp, 0, delta);
            }

            tail = 0;
            head = delta;
            Items = temp;
        }

        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Can't dequeue on empty queue");
            }

            var itemToReturn = Items[tail];
            Items[tail] = default(T);
            Count--;
            tail++;

            //check if the array is wrapped
            if (head < tail && tail == Items.Length)
            {
                tail = 0;
            }

            return itemToReturn;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }
    }
}
