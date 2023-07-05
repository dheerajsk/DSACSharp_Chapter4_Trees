using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4_Trees.AVLTree
{
    public class AVLTreeDemo
    {
        public static void Main(){
            AVLTree<int> tree = new AVLTree<int>();
            tree.root = tree.Insert(tree.root, 10);
            tree.root = tree.Insert(tree.root, 20);
            tree.root = tree.Insert(tree.root, 30);
            tree.root = tree.Insert(tree.root, 40);
            tree.root = tree.Insert(tree.root, 50);
            tree.root = tree.Insert(tree.root, 25);

            Console.WriteLine("Preorder traversal of constructed tree is : ");
            tree.PreOrder(tree.root);

            tree.root = tree.Delete(tree.root, 20);

            Console.WriteLine("\nPreorder traversal after deletion of 20:");
            tree.PreOrder(tree.root);

        }
    }
}