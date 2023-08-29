using System;

class TreeNode
{
    public int Value;
    public TreeNode Left;
    public TreeNode Right;

    public TreeNode(int value)
    {
        Value = value;
        Left = null;
        Right = null;
    }
}

class BinaryTree
{
    public TreeNode Root;

    public BinaryTree()
    {
        Root = null;
    }

    // Pre-order traversal: Root -> Left -> Right
    public void PreOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            Console.Write(node.Value + " ");
            PreOrderTraversal(node.Left);
            PreOrderTraversal(node.Right);
        }
    }

    // In-order traversal: Left -> Root -> Right
    public void InOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.Write(node.Value + " ");
            InOrderTraversal(node.Right);
        }
    }

    // Post-order traversal: Left -> Right -> Root
    public void PostOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            PostOrderTraversal(node.Left);
            PostOrderTraversal(node.Right);
            Console.Write(node.Value + " ");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        tree.Root = new TreeNode(1);
        tree.Root.Left = new TreeNode(9);
        tree.Root.Left.Left = new TreeNode(5);
        tree.Root.Left.Right = new TreeNode(6);
        tree.Root.Left.Right.Left = new TreeNode(3);
        tree.Root.Left.Right.Right = new TreeNode(4);
        tree.Root.Right = new TreeNode(2);
        tree.Root.Right.Right = new TreeNode(7);
        tree.Root.Right.Right.Left = new TreeNode(8);

        Console.WriteLine("Pre-order traversal:");
        tree.PreOrderTraversal(tree.Root);
        Console.WriteLine();

        Console.WriteLine("In-order traversal:");
        tree.InOrderTraversal(tree.Root);
        Console.WriteLine();

        Console.WriteLine("Post-order traversal:");
        tree.PostOrderTraversal(tree.Root);
        Console.WriteLine();
    }
}
