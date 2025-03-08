using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(10); // ignore

        Console.WriteLine("Checking Contains Method:");
        Console.WriteLine(tree.Contains(5));  // True
        Console.WriteLine(tree.Contains(20)); // False

        Console.WriteLine("\nTraversing Backwards:");
        foreach (var val in tree.TraverseBackward())
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();

        Console.WriteLine($"\nTree Height: {tree.GetHeight()}");

        List<int> sortedList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        BinarySearchTree balancedTree = BinarySearchTree.CreateTreeFromSortedList(sortedList);
        Console.WriteLine($"\nBalanced Tree Height: {balancedTree.GetHeight()}");
    }
}