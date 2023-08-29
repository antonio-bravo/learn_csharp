using System;
using System.Collections.Generic;

class TreeNode<T>
{
    public T Data { get; set; }
    public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();

    public TreeNode(T data)
    {
        Data = data;
    }
}

class Tree<T>
{
    public TreeNode<T> Root { get; set; }

    public Tree(T rootData)
    {
        Root = new TreeNode<T>(rootData);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a simple tree
        Tree<int> tree = new Tree<int>(100);

        TreeNode<int> node1 = new TreeNode<int>(1);
        TreeNode<int> node2 = new TreeNode<int>(50);
        TreeNode<int> node3 = new TreeNode<int>(150);
        TreeNode<int> node4 = new TreeNode<int>(30);
        TreeNode<int> node5 = new TreeNode<int>(96);

        tree.Root.Children.Add(node1);
        tree.Root.Children.Add(node2);
        tree.Root.Children.Add(node3);

        node4.Children.Add(node5);
        tree.Root.Children.Add(node4);

        // Printing tree structure
        PrintTree(tree.Root, 0);

        Console.ReadLine();
    }

    static void PrintTree<T>(TreeNode<T> node, int level)
    {
        Console.WriteLine(new string('-', level * 2) + node.Data);

        foreach (var child in node.Children)
        {
            PrintTree(child, level + 1);
        }
    }
}
