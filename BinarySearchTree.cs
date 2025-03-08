using System;
using System.Collections.Generic;

public class BinarySearchTree
{
    public Node Root;

    public BinarySearchTree()
    {
        Root = null;
    }

    public void Insert(int value)
    {
        if (Root == null)
        {
            Root = new Node(value);
        }
        else
        {
            Root.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        return Root != null && Root.Contains(value);
    }

    public IEnumerable<int> TraverseBackward()
    {
        if (Root != null)
        {
            foreach (var value in Root.TraverseBackward()) yield return value;
        }
    }

    public int GetHeight()
    {
        return Root == null ? 0 : Root.GetHeight();
    }

    public static void InsertMiddle(BinarySearchTree tree, List<int> sortedList, int first, int last)
    {
        if (first > last) return;
        
        int mid = (first + last) / 2;
        tree.Insert(sortedList[mid]);
        
        InsertMiddle(tree, sortedList, first, mid - 1);
        InsertMiddle(tree, sortedList, mid + 1, last);
    }

    public static BinarySearchTree CreateTreeFromSortedList(List<int> sortedList)
    {
        var tree = new BinarySearchTree();
        InsertMiddle(tree, sortedList, 0, sortedList.Count - 1);
        return tree;
    }
}