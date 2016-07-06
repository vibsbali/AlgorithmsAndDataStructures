using System;
using System.Collections.Generic;

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

        public bool Delete(string key)
        {
            var pathToKey = new Stack<Node<T>>();
            //Find out if key exist
            var result = Remove(root, key, 0, pathToKey);
            while (pathToKey.Count > 1 && result != null) //Setting count > 1 because we do not want to remove root node we could also use do while with condition 
            {                                               //where node != root
                var node = pathToKey.Pop();
                for (int i = 0; i < Radix; i++)
                {
                    if (node.Next[i] == null)
                    {
                        node = null;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return result != null;
        }

        //path is a stack of all the nodes upto key which can be used to remove if required
        private Node<T> Remove(Node<T> node, string key, int d, Stack<Node<T>> path)
        {
            if (node == null)
            {
                return null;
            }

            path.Push(node);
            if (d == key.Length)
            {
                node.Value = null;
                return node;
            }
            else
            {
                var c = key[d];
                Remove(node.Next[c], key, d + 1, path);
            }
            return null;
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
            //This is our terminating statement for recursion
            if (node == null)
            {
                return;
            }

            //This is how we find out whether the node has a value and should be enqued or not
            if (node.Value != null)
            {
                queue.Enqueue(prefix);
            }

            //In the next statement prefix + (char)i is the most important and is how string is built
            //When (char)i will be \0 if the node value is null otherwise it would be char value of associated ascii value
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
