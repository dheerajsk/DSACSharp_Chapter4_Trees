using System;
using System.Collections.Generic;

namespace Chapter4_Trees.BST
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> Root { get; set; }

        public void Print(Node<T> node, string indent = "", string prefix = "")
        {
            if (node != null)
            {
                Console.WriteLine($"{indent}{prefix}{node.Data}");
                if (node.Left != null) Print(node.Left, indent + "  ", "L: ");
                if (node.Right != null) Print(node.Right, indent + "  ", "R: ");
            }
        }

        public Node<T> Search(Node<T> root, T data)
        {
            if (root == null || root.Data.CompareTo(data) == 0)
                return root;

            if (root.Data.CompareTo(data) > 0)
                return Search(root.Left, data);

            return Search(root.Right, data);
        }

        public Node<T> Delete(Node<T> root, T data)
        {
            if (root == null) return root;

            if (data.CompareTo(root.Data) < 0)
                root.Left = Delete(root.Left, data);
            else if (data.CompareTo(root.Data) > 0)
                root.Right = Delete(root.Right, data);
            else
            {
                if (root.Left == null && root.Right == null)
                    root = null;
                else if (root.Left == null)
                {
                    Node<T> temp = root;
                    root = root.Right;
                    temp = null;
                }
                else if (root.Right == null)
                {
                    Node<T> temp = root;
                    root = root.Left;
                    temp = null;
                }
                else
                {
                    Node<T> temp = FindMin(root.Right);
                    root.Data = temp.Data;
                    root.Right = Delete(root.Right, temp.Data);
                }
            }
            return root;
        }

        public Node<T> FindMin(Node<T> root)
        {
            while (root.Left != null)
                root = root.Left;

            return root;
        }

        public Node<T> Insert(Node<T> root, T data)
        {
            if (root == null)
                root = new Node<T>(data);
            else if (data.CompareTo(root.Data) < 0)
                root.Left = Insert(root.Left, data);
            else if (data.CompareTo(root.Data) > 0)
                root.Right = Insert(root.Right, data);

            return root;
        }

        public void PreOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                Console.Write(node.Data + " ");
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void InOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.Write(node.Data + " ");
                InOrderTraversal(node.Right);
            }
        }

        public void PostOrderTraversal(Node<T> node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Console.Write(node.Data + " ");
            }
        }

        public void LevelOrderTraversal(Node<T> root)
        {
            if (root == null) return;

            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();

                Console.Write(node.Data + " ");

                if (node.Left != null) queue.Enqueue(node.Left);
                if (node.Right != null) queue.Enqueue(node.Right);
            }
        }
    }
}
           
