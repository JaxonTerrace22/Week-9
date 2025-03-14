using System;
using System.Collections.Generic;
using System.Linq;
using prove_09;  // Ensure access to BinarySearchTree and related classes

class Program
{
    static void Main()
    {
        BinarySearchTree tree = new BinarySearchTree();
        tree.Insert(10);
        tree.Insert(5);
        tree.Insert(15);
        tree.Insert(10); // duplicate, should be ignored

        Console.WriteLine("Checking Contains Method:");
        Console.WriteLine(tree.Contains(5));  // True
        Console.WriteLine(tree.Contains(20)); // False

        Console.WriteLine("\nTraversing Backwards:");
        // Call the new Reverse() method instead of the removed TraverseBackward()
        foreach (var val in tree.Reverse())
        {
            Console.Write(val + " ");
        }
        Console.WriteLine();

        Console.WriteLine($"\nTree Height: {tree.GetHeight()}");

        List<int> sortedList = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
        // Create a balanced tree using our local helper method.
        BinarySearchTree balancedTree = CreateTreeFromSortedList(sortedList.ToArray());
        Console.WriteLine($"\nBalanced Tree Height: {balancedTree.GetHeight()}");
    }

    /// <summary>
    /// Given a sorted array of integers, create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        BinarySearchTree bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Recursively inserts the middle element of the subarray into the BST.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return;
        int mid = (first + last) / 2;
        bst.Insert(sortedNumbers[mid]);
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}