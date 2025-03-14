using System.Collections;

namespace prove_09;

public class BinarySearchTree : IEnumerable<int> {
    private Node? _root;

    /// <summary>
    /// Insert a new node into the tree.
    /// </summary>
    public void Insert(int value) {
        // Only insert if the value is not already in the tree.
        if (Contains(value))
            return;

        // Create a new node.
        Node newNode = new Node(value);
        // If the tree is empty, then point root to the new node.
        if (_root is null)
            _root = newNode;
        // If the tree is not empty, then delegate insertion to the root.
        else
            _root.Insert(value);
    }

    /// <summary>
    /// Check to see if the tree contains a certain value.
    /// </summary>
    /// <param name="value">The value to look for</param>
    /// <returns>true if found, otherwise false</returns>
    public bool Contains(int value) {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Yields all values in the tree (in order).
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST (in-order traversal).
    /// </summary>
    public IEnumerator<int> GetEnumerator() {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
            yield return number;
    }

    private void TraverseForward(Node? node, List<int> values) {
        if (node is not null) {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST (reverse in-order traversal).
    /// </summary>
    public IEnumerable Reverse() {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
            yield return number;
    }

    private void TraverseBackward(Node? node, List<int> values) {
        if (node is not null) {
            TraverseBackward(node.Right, values);
            values.Add(node.Data);
            TraverseBackward(node.Left, values);
        }
    }

    /// <summary>
    /// Get the height of the tree.
    /// </summary>
    public int GetHeight() {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString() {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }
}

/// <summary>
/// Represents a node in the binary search tree.
/// </summary>
public class Node {
    public int Data { get; private set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public Node(int data) {
        Data = data;
    }

    /// <summary>
    /// Recursively inserts a value into the subtree.
    /// (Precondition: the value is not already in the tree.)
    /// </summary>
    public void Insert(int value) {
        if (value < Data) {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value equals Data, do nothing (no duplicates allowed).
    }

    /// <summary>
    /// Recursively searches for a value in the subtree.
    /// </summary>
    public bool Contains(int value) {
        if (value == Data)
            return true;
        else if (value < Data)
            return Left != null && Left.Contains(value);
        else // value > Data
            return Right != null && Right.Contains(value);
    }

    /// <summary>
    /// Recursively computes the height of the subtree.
    /// </summary>
    public int GetHeight() {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
