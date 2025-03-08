using System;
using System.Collections.Generic;

public class TreesTester
{
    public static void RunTests()
    {
        BinarySearchTree tree = new BinarySearchTree();
        
        // unique values
        tree.Insert(50);
        tree.Insert(30);
        tree.Insert(70);
        tree.Insert(30); //should not be inserted

        Console.WriteLine(tree.Contains(30)); //true
        Console.WriteLine(tree.Contains(100)); // false

        Console.WriteLine("\nTraversing Backwards:");
        foreach (var value in tree.TraverseBackward())
        {
            Console.Write(value + " ");
        }
        Console.WriteLine();

        Console.WriteLine($"\nTree Height: {tree.GetHeight()}");

        List<int> sortedList = new List<int> { 10, 20, 30, 40, 50, 60, 70 };
        BinarySearchTree balancedTree = BinarySearchTree.CreateTreeFromSortedList(sortedList);
        Console.WriteLine($"Balanced Tree Height: {balancedTree.GetHeight()}");
    }
}