using System;
using System.Collections.Generic;

namespace StringSortingAlgorithms
{
    public class Trie<T>
    {
        private const short Radix = 256;
        private readonly Node<T> root = new Node<T>();

        private class Node<T>
        {
            public object Value;
            public readonly Node<T>[] Next = new Node<T>[Radix];
        }

        public void Put(string key, T value)
        {
            Insert(root, key, value, 0);
        }

        private void Insert(Node<T> node, string key, T value, int d)
        {
            if (node == null)
            {
                throw new InvalidOperationException("Node cannot be null");
            }

            if (d == key.Length)
            {
                node.Value = value;
                return;
            }

            //Otherwise 
            //find the character at a specified postion in the string denoted by d
            char c = key[d];
            //Only create new node only if it is not present in the chain
            //Value of char c will be converted to its ascii value and will be used in the array (key index)
            if (node.Next[c] == null)
            {
                node.Next[c] = new Node<T>();
            }
            Insert(node.Next[c], key, value, d + 1);
        }

        public T Get(string key)
        {
            if (key == null)
            {
                throw new InvalidOperationException("Key cannot be null");
            }

            return Search(root, key, 0);
        }

        private T Search(Node<T> node, string key, int d)
        {
            if (node == null)
            {
                //following line will return 0 for int which may be ambigous
                //return default(T);
                throw new KeyNotFoundException("The given key was not present in the Trie");
            }

            if (d == key.Length)
            {
                if (node.Value != null)
                {
                    return (T)node.Value;
                }
                //otherwise
                //following is to handle ambiguity of int default to 0
                throw new KeyNotFoundException("The given key was not present in the Trie");
            }

            //find the character at a specified postion in the string denoted by d
            char c = key[d];
            return Search(node.Next[c], key, d + 1);
        }
    }
}
