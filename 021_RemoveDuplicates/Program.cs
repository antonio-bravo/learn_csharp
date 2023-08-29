using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> names = new List<string>()
        {
            "Marcin",
            "Mary",
            "James",
            "Albert",
            "Lily",
            "Emily",
            "marcin",
            "James",
            "Jane"
        };

        Console.WriteLine("Unsorted list:\n");
        foreach (string name in names)
        {
            Console.WriteLine(name);
        }

        SortedSet<string> sorted = new SortedSet<string>(
            names,
            Comparer<string>.Create((a, b) =>
                a.ToLower().CompareTo(b.ToLower())));

        Console.WriteLine("\nSorted list:\n");
        foreach (string name in sorted)
        {
            Console.WriteLine(name);
        }
    }
}
