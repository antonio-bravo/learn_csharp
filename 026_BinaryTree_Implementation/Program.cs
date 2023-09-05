using System;
using System.Collections.Generic;

public class TreeNode<T>
{
    public T Data { get; set; }
    public TreeNode<T> Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; }

    public int GetHeight()
    {
        int height = 1;
        TreeNode<T> current = this;
        while (current.Parent != null)
        {
            height++;
            current = current.Parent;
        }
        return height;
    }
}

public class BinaryTreeNode<T> : TreeNode<T>
{
    public BinaryTreeNode() => Children =
        new List<TreeNode<T>>() { null, null };

    public BinaryTreeNode<T> Left
    {
        get { return (BinaryTreeNode<T>)Children[0]; }
        set { Children[0] = value; }
    }

    public BinaryTreeNode<T> Right
    {
        get { return (BinaryTreeNode<T>)Children[1]; }
        set { Children[1] = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create binary tree nodes
        var rootNode = new BinaryTreeNode<int> { Data = 1 };
        var leftNode = new BinaryTreeNode<int> { Data = 2 };
        var rightNode = new BinaryTreeNode<int> { Data = 3 };

        // Connect nodes to build the binary tree
        rootNode.Left = leftNode;
        rootNode.Right = rightNode;
        leftNode.Parent = rootNode;
        rightNode.Parent = rootNode;

        // Perform some operations
        Console.WriteLine("Root Node Data: " + rootNode.Data);
        Console.WriteLine("Left Node Data: " + rootNode.Left.Data);
        Console.WriteLine("Right Node Data: " + rootNode.Right.Data);
        Console.WriteLine("Height of Left Node: " + leftNode.GetHeight());
        Console.WriteLine("Height of Right Node: " + rightNode.GetHeight());
    }
}
