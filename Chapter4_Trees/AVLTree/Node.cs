using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4_Trees.AVLTree
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Left;
        public Node<T> Right;
        public int Height;

        public Node(T data)
        {
            this.Data = data;
            this.Height = 1;
        }
    }
}