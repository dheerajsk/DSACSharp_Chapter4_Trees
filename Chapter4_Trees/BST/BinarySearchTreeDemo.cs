
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4_Trees.BST
{
    public class BinarySearchTreeDemo{
        
        public static void Main()
        {
        BinarySearchTree<int> bst = new BinarySearchTree<int>();

        bst.Root = bst.Insert(bst.Root, 50);
        bst.Insert(bst.Root, 30);
        bst.Insert(bst.Root, 20);
        bst.Insert(bst.Root, 40);
        bst.Insert(bst.Root, 70);
        bst.Insert(bst.Root, 60);
        bst.Insert(bst.Root, 80);

        Console.WriteLine("In-order traversal of the BST:");
        bst.InOrderTraversal(bst.Root);

        Console.WriteLine("\nPre-order traversal of the BST:");
        bst.PreOrderTraversal(bst.Root);

        Console.WriteLine("\nPost-order traversal of the BST:");
        bst.PostOrderTraversal(bst.Root);
        
        Console.WriteLine("\nLevel-order traversal of the BST:");
        bst.LevelOrderTraversal(bst.Root);
        
        bst.Delete(bst.Root, 20);
        
        Console.WriteLine("\nIn-order traversal after deleting 20:");
        bst.InOrderTraversal(bst.Root);
    }

    }
}