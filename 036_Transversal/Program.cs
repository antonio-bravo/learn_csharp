using System;
using System.Collections.Generic;

public class FibonacciHeap<T> where T : IComparable<T>
{
    private FibonacciNode<T> minimumNode;
    private List<FibonacciNode<T>> nodes = new List<FibonacciNode<T>>();

    // Inserta un nuevo elemento en el montículo de Fibonacci.
    public void Insert(T value)
    {
        var newNode = new FibonacciNode<T>(value);
        nodes.Add(newNode);

        if (minimumNode == null || value.CompareTo(minimumNode.Value) < 0)
        {
            minimumNode = newNode;
        }
    }

    // Extrae el elemento mínimo del montículo de Fibonacci.
    public T ExtractMin()
    {
        if (minimumNode == null)
        {
            throw new InvalidOperationException("El montículo de Fibonacci está vacío.");
        }

        var min = minimumNode;
        nodes.Remove(minimumNode);
        minimumNode = null;

        // Consolidar los árboles en el montículo
        Consolidate();

        return min.Value;
    }

    // Une dos montículos de Fibonacci.
    public void Union(FibonacciHeap<T> otherHeap)
    {
        nodes.AddRange(otherHeap.nodes);

        if (otherHeap.minimumNode != null && (minimumNode == null || otherHeap.minimumNode.Value.CompareTo(minimumNode.Value) < 0))
        {
            minimumNode = otherHeap.minimumNode;
        }
    }

    // Realiza la consolidación de árboles en el montículo.
    private void Consolidate()
    {
        var maxDegree = (int)Math.Ceiling(Math.Log(nodes.Count, (1 + Math.Sqrt(5)) / 2));
        var degreeTable = new List<FibonacciNode<T>>(maxDegree + 2);

        for (int i = 0; i < nodes.Count; i++)
        {
            var x = nodes[i];
            var degree = x.Degree;

            while (degreeTable.Count <= degree)
            {
                degreeTable.Add(null);
            }

            while (degreeTable[degree] != null)
            {
                var y = degreeTable[degree];
                if (x.Value.CompareTo(y.Value) > 0)
                {
                    var temp = x;
                    x = y;
                    y = temp;
                }

                Link(y, x);
                degreeTable[degree] = null;
                degree++;
            }

            degreeTable[degree] = x;
        }

        minimumNode = null;

        for (int i = 0; i < degreeTable.Count; i++)
        {
            var node = degreeTable[i];
            if (node != null)
            {
                if (minimumNode == null || node.Value.CompareTo(minimumNode.Value) < 0)
                {
                    minimumNode = node;
                }
            }
        }
    }

    // Realiza la operación de enlace durante la consolidación.
    private void Link(FibonacciNode<T> y, FibonacciNode<T> x)
    {
        nodes.Remove(y);
        x.AddChild(y);
    }
}

public class FibonacciNode<T>
{
    public T Value { get; }
    public FibonacciNode<T> Parent { get; private set; }
    public FibonacciNode<T> Child { get; private set; }
    public FibonacciNode<T> Next { get; private set; }
    public FibonacciNode<T> Prev { get; private set; }
    public int Degree { get; private set; }
    public bool Marked { get; private set; }

    public FibonacciNode(T value)
    {
        Value = value;
        Next = this;
        Prev = this;
    }

    public void AddChild(FibonacciNode<T> child)
    {
        if (Child == null)
        {
            Child = child;
        }
        else
        {
            child.Next = Child;
            child.Prev = Child.Prev;
            Child.Prev.Next = child;
            Child.Prev = child;
        }

        child.Parent = this;
        Degree++;
        child.Marked = false;
    }
}
class Program
{
    static void Main()
    {
        var fibonacciHeap = new FibonacciHeap<int>();

        fibonacciHeap.Insert(5);
        fibonacciHeap.Insert(3);
        fibonacciHeap.Insert(8);

        int min = fibonacciHeap.ExtractMin();
        Console.WriteLine("Elemento mínimo: " + min);
    }
}