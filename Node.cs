public class Node
{
    public int Value;
    public Node Left;
    public Node Right;

    public Node(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }

    public void Insert(int value)
    {
        if (value == Value) return; // this prevents duplicats

        if (value < Value)
        {
            if (Left == null) Left = new Node(value);
            else Left.Insert(value);
        }
        else
        {
            if (Right == null) Right = new Node(value);
            else Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Value) return true;
        if (value < Value) return Left != null && Left.Contains(value);
        return Right != null && Right.Contains(value);
    }

    public IEnumerable<int> TraverseBackward()
    {
        if (Right != null)
        {
            foreach (var value in Right.TraverseBackward()) yield return value;
        }
        
        yield return Value;
        
        if (Left != null)
        {
            foreach (var value in Left.TraverseBackward()) yield return value;
        }
    }

    public int GetHeight()
    {
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}