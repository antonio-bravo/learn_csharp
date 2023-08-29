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

public class Tree<T>
{
    public TreeNode<T> Root { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Tree<int> tree = new Tree<int>();
        tree.Root = new TreeNode<int>() { Data = 100 };
        tree.Root.Children = new List<TreeNode<int>>
        {
            new TreeNode<int>() { Data = 50, Parent = tree.Root },
            new TreeNode<int>() { Data = 1, Parent = tree.Root },
            new TreeNode<int>() { Data = 150, Parent = tree.Root }
        };
        tree.Root.Children[2].Children = new List<TreeNode<int>>()
        {
            new TreeNode<int>()
            { Data = 30, Parent = tree.Root.Children[2] }
        };

        Console.WriteLine("Tree Hierarchy:");
        PrintTree(tree.Root, 0);

        // Example of getting height
        int height = tree.Root.Children[2].Children[0].GetHeight();
        Console.WriteLine($"Height of the node with value 30: {height}");
    }

    static void PrintTree(TreeNode<int> node, int level)
    {
        string indentation = new string(' ', level * 4);
        Console.WriteLine($"{indentation}Node: {node.Data}");

        if (node.Children != null)
        {
            foreach (var child in node.Children)
            {
                PrintTree(child, level + 1);
            }
        }
    }
}
