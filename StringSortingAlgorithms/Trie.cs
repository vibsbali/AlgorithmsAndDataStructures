using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace StringSortingAlgorithms
{
    public class Trie<T>
    {
        private const short Radix = 256;
        private readonly Node<T> root = new Node<T>();

        private class Node<T1>
        {
            public object Value;
            public readonly Node<T1>[] Next = new Node<T1>[Radix];
        }


        public IEnumerable<string> KeysWithPrefix(string prefix)
        {
            var queue = new Queue<string>();
            var node = RetrieveNode(root, prefix, 0);
            Collect(node, prefix,queue);
            return queue;
        } 

        //Inorder traversal
        private void Collect(Node<T> node, string prefix, Queue<string> queue)
        {
            if (node == null)
            {
                return;
            }

            if (node.Value != null)
            {
                queue.Enqueue(prefix);
            }

            for (int i = 0; i < Radix; i++)
            {
                Collect(node.Next[i], prefix + (char)i, queue);
            }
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

            var node = RetrieveNode(root, key, 0);
            if (node.Value != null)
            {
                return (T)node.Value;
            }
            //otherwise
            //following is to handle ambiguity of int default to 0
            throw new KeyNotFoundException("The given key was not present in the Trie");
        }

        private Node<T> RetrieveNode(Node<T> node, string key, int d)
        {
            if (node == null)
            {
                //following line will return 0 for int which may be ambigous
                //return default(T);
                throw new KeyNotFoundException("The given key was not present in the Trie");
            }

            if (d == key.Length)
            {
               return node;
            }

            //find the character at a specified postion in the string denoted by d
            char c = key[d];
            return RetrieveNode(node.Next[c], key, d + 1);
        }
    }
}
