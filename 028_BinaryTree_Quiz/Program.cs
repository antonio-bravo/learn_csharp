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

public enum TraversalEnum
{
    PREORDER,
    INORDER,
    POSTORDER
}

public class BinaryTree<T>
{
    public BinaryTreeNode<T> Root { get; set; }
    public int Count { get; set; }

    private void TraversePreOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            result.Add(node);
            TraversePreOrder(node.Left, result);
            TraversePreOrder(node.Right, result);
        }
    }

    private void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraverseInOrder(node.Left, result);
            result.Add(node);
            TraverseInOrder(node.Right, result);
        }
    }

    private void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
    {
        if (node != null)
        {
            TraversePostOrder(node.Left, result);
            TraversePostOrder(node.Right, result);
            result.Add(node);
        }
    }

    public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode)
    {
        List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>();
        switch (mode)
        {
            case TraversalEnum.PREORDER:
                TraversePreOrder(Root, nodes);
                break;
            case TraversalEnum.INORDER:
                TraverseInOrder(Root, nodes);
                break;
            case TraversalEnum.POSTORDER:
                TraversePostOrder(Root, nodes);
                break;
        }
        return nodes;
    }

    public int GetHeight()
    {
        int height = 0;
        foreach (BinaryTreeNode<T> node in Traverse(TraversalEnum.PREORDER))
        {
            height = Math.Max(height, node.GetHeight());
        }
        return height;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Crear un árbol binario de ejemplo
        var root = new BinaryTreeNode<int> { Data = 1 };
        var left = new BinaryTreeNode<int> { Data = 2 };
        var right = new BinaryTreeNode<int> { Data = 3 };
        var leftLeft = new BinaryTreeNode<int> { Data = 4 };
        var leftRight = new BinaryTreeNode<int> { Data = 5 };

        root.Left = left;
        root.Right = right;
        left.Left = leftLeft;
        left.Right = leftRight;

        // Crear un árbol binario y asignar el nodo raíz
        var binaryTree = new BinaryTree<int> { Root = root };

        // Realizar diferentes recorridos en el árbol binario
        Console.WriteLine("Recorrido en preorden:");
        var preOrderNodes = binaryTree.Traverse(TraversalEnum.PREORDER);
        foreach (var node in preOrderNodes)
        {
            Console.Write(node.Data + " ");
        }

        Console.WriteLine("\n\nRecorrido en orden:");
        var inOrderNodes = binaryTree.Traverse(TraversalEnum.INORDER);
        foreach (var node in inOrderNodes)
        {
            Console.Write(node.Data + " ");
        }

        Console.WriteLine("\n\nRecorrido en postorden:");
        var postOrderNodes = binaryTree.Traverse(TraversalEnum.POSTORDER);
        foreach (var node in postOrderNodes)
        {
            Console.Write(node.Data + " ");
        }

        Console.WriteLine("\n\nAltura del árbol: " + binaryTree.GetHeight());
    }
}
