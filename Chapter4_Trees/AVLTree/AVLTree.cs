using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4_Trees.AVLTree
{
    public class AVLTree<T> where T : IComparable
{
    public Node<T> root;

    public int Height(Node<T> N)
    {
        if (N == null)
            return 0;
        return N.Height;
    }

    public Node<T> Insert(Node<T> node, T data)
    {
        /* 1.  Perform the normal BST insertion */
        if (node == null)
            return new Node<T>(data);

        if (data.CompareTo(node.Data) < 0)
            node.Left = Insert(node.Left, data);
        else if (data.CompareTo(node.Data) > 0)
            node.Right = Insert(node.Right, data);

        /* 2. Update height of this ancestor node */
        node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

        /* 3. Get the balance factor of this ancestor node to check whether
       this node became unbalanced */
        int balance = GetBalance(node);

        // If this node becomes unbalanced, then there are 4 cases

        // Left Left Case
        if (balance > 1 && data.CompareTo(node.Left.Data) < 0)
            return RightRotate(node);

        // Right Right Case
        if (balance < -1 && data.CompareTo(node.Right.Data) > 0)
            return LeftRotate(node);

        // Left Right Case
        if (balance > 1 && data.CompareTo(node.Left.Data) > 0)
        {
            node.Left = LeftRotate(node.Left);
            return RightRotate(node);
        }

        // Right Left Case
        if (balance < -1 && data.CompareTo(node.Right.Data) < 0)
        {
            node.Right = RightRotate(node.Right);
            return LeftRotate(node);
        }

        return node;
    }

    public Node<T> RightRotate(Node<T> y)
    {
        Node<T> x = y.Left;
        Node<T> T2 = x.Right;

        x.Right = y;
        y.Left = T2;

        y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
        x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

        return x;
    }

    public Node<T> LeftRotate(Node<T> x)
    {
        Node<T> y = x.Right;
        Node<T> T2 = y.Left;

        y.Left = x;
        x.Right = T2;

        x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
        y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

        return y;
    }

    public int GetBalance(Node<T> N)
    {
        if (N == null)
            return 0;
        return Height(N.Left) - Height(N.Right);
    }

    public void PreOrder(Node<T> node)
    {
        if (node != null)
        {
            Console.Write(node.Data + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }
    }

    public Node<T> Delete(Node<T> root, T data)
    {
        if (root == null)
            return root;

        if (data.CompareTo(root.Data) < 0)
            root.Left = Delete(root.Left, data);
        else if (data.CompareTo(root.Data) > 0)
            root.Right = Delete(root.Right, data);
        else
        {
            if ((root.Left == null) || (root.Right == null))
            {
                Node<T> temp = null;
                if (temp == root.Left)
                    temp = root.Right;
                else
                    temp = root.Left;

                if (temp == null)
                    root = null;
                else
                    root = temp;
            }
            else
            {
                Node<T> temp = minValueNode(root.Right);
                root.Data = temp.Data;
                root.Right = Delete(root.Right, temp.Data);
            }
        }

        if (root == null)
            return root;

        root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;

        int balance = GetBalance(root);

        if (balance > 1 && GetBalance(root.Left) >= 0)
            return RightRotate(root);

        if (balance < -1 && GetBalance(root.Right) <= 0)
            return LeftRotate(root);

        if (balance > 1 && GetBalance(root.Left) < 0)
        {
            root.Left = LeftRotate(root.Left);
            return RightRotate(root);
        }

        if (balance < -1 && GetBalance(root.Right) > 0)
        {
            root.Right = RightRotate(root.Right);
            return LeftRotate(root);
        }

        return root;
    }

    public Node<T> minValueNode(Node<T> node)
    {
        Node<T> current = node;
        while (current.Left != null)
            current = current.Left;

        return current;
    }
}
}