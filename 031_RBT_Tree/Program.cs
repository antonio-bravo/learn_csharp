using System;
using TreeLib;

class Program
{
    static void Main()
    {
        // Create a Red-Black Tree to store integer values
        RedBlackTreeList<int> tree = new RedBlackTreeList<int>();

        // Add integers from 1 to 10 to the tree
        for (int i = 1; i <= 10; i++)
        {
            tree.Add(i);
        }

        // Remove the node with the value 9
        tree.Remove(9);

        // Check if the tree contains the value 5
        bool contains = tree.ContainsKey(5);
        Console.WriteLine("Does value exist? " + (contains ? "yes" : "no"));

        // Get the count, greatest, and least values in the tree
        uint count = tree.Count;
        tree.Greatest(out int greatest);
        tree.Least(out int least);
        Console.WriteLine($"{count} elements in the range {least}-{greatest}");

        // Get all values in the tree using GetEnumerable method
        Console.WriteLine("Values: " + string.Join(", ", tree.GetEnumerable()));

        // Iterate through nodes in the tree using foreach loop
        Console.Write("Values: ");
        foreach (var node in tree)
        {
            Console.Write(node.Key + " ");
        }
        Console.WriteLine();
    }
}
