using System;
using System.Collections;
using System.Collections.Generic;

namespace FundamentalDataStructures
{
    public class Stack<T> : IStack<T>
    {
        private int Size { get; }
        private T[] Items { get; set; }
       
        public int Count { get; private set; }


        public Stack(int size)
        {
            Size = size;
            Items = new T[Size];
        }

        public Stack() : this(16)
        {
        }

        public void Push(T item)
        {
            if (Count == Items.Length)
            {
                Resize(Items.Length * 2);
            }
            Items[Count] = item;
            Count++;
        }

        private void Resize(int newSize)
        {
            var newArray = new T[newSize];
            Array.Copy(Items, 0, newArray, 0, Count);
            Items = newArray;
        }

        public T Pop()
        {
            var item = Items[--Count];
            Items[Count] = default(T);//Avoid Loitring
            if (Count > 0 && Count == Items.Length / 4)
            {
                Resize(Items.Length / 2);  
            }

            return item;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count-1; i >= 0; i--)
            {
                yield return Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
