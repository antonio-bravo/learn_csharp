using System;
using System.Collections.Generic;

public class BinomialNode<T> where T : IComparable<T>
{
    public T Key { get; set; }
    public int Degree { get; set; }
    public BinomialNode<T> Parent { get; set; }
    public BinomialNode<T> Child { get; set; }
    public BinomialNode<T> Sibling { get; set; }

    public BinomialNode(T key)
    {
        Key = key;
        Degree = 0;
        Parent = null;
        Child = null;
        Sibling = null;
    }
}

public class BinomialHeap<T> where T : IComparable<T>
{
    private BinomialNode<T> minRoot;

    public bool IsEmpty()
    {
        return minRoot == null;
    }

    public void Insert(T key)
    {
        BinomialHeap<T> newHeap = new BinomialHeap<T>();
        newHeap.minRoot = new BinomialNode<T>(key);
        Merge(newHeap);
    }

    public T GetMinimum()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("El montículo binomial está vacío.");
        }

        BinomialNode<T> minNode = minRoot;
        BinomialNode<T> current = minRoot;

        while (current != null)
        {
            if (current.Key.CompareTo(minNode.Key) < 0)
            {
                minNode = current;
            }
            current = current.Sibling;
        }

        return minNode.Key;
    }

    public void DeleteMinimum()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("El montículo binomial está vacío.");
        }

        // Encontrar el nodo mínimo y su índice
        BinomialNode<T> minNode = minRoot;
        BinomialNode<T> prevMinNode = null;
        BinomialNode<T> current = minRoot;
        BinomialNode<T> prevNode = null;
        int minIndex = 0;
        int currentIndex = 0;

        while (current != null)
        {
            if (current.Key.CompareTo(minNode.Key) < 0)
            {
                minNode = current;
                minIndex = currentIndex;
                prevMinNode = prevNode;
            }

            prevNode = current;
            current = current.Sibling;
            currentIndex++;
        }

        // Eliminar el nodo mínimo de la lista de raíces
        if (prevMinNode == null)
        {
            minRoot = minNode.Sibling;
        }
        else
        {
            prevMinNode.Sibling = minNode.Sibling;
        }

        // Crear un nuevo montículo con los hijos del nodo mínimo
        BinomialHeap<T> newHeap = new BinomialHeap<T>();
        BinomialNode<T> child = minNode.Child;

        while (child != null)
        {
            BinomialNode<T> next = child.Sibling;
            child.Sibling = null;
            newHeap.minRoot = Merge(newHeap.minRoot, child);
            child = next;
        }

        // Unir el nuevo montículo con el montículo original
        minRoot = Merge(minRoot, newHeap.minRoot);
    }

    private void Merge(BinomialHeap<T> heap)
    {
        this.minRoot = Merge(this.minRoot, heap.minRoot);
    }

    private BinomialNode<T> Merge(BinomialNode<T> root1, BinomialNode<T> root2)
    {
        BinomialNode<T> newRoot = null;
        BinomialNode<T> current1 = root1;
        BinomialNode<T> current2 = root2;
        BinomialNode<T> tail = null;

        while (current1 != null && current2 != null)
        {
            if (current1.Degree <= current2.Degree)
            {
                if (tail == null)
                {
                    newRoot = current1;
                }
                else
                {
                    tail.Sibling = current1;
                }

                tail = current1;
                current1 = current1.Sibling;
            }
            else
            {
                if (tail == null)
                {
                    newRoot = current2;
                }
                else
                {
                    tail.Sibling = current2;
                }

                tail = current2;
                current2 = current2.Sibling;
            }
        }

        if (current1 != null)
        {
            tail.Sibling = current1;
        }
        else
        {
            tail.Sibling = current2;
        }

        return newRoot;
    }
}

class Program
{
    static void Main()
    {
        BinomialHeap<int> binomialHeap = new BinomialHeap<int>();

        binomialHeap.Insert(5);
        binomialHeap.Insert(2);
        binomialHeap.Insert(8);
        binomialHeap.Insert(1);

        Console.WriteLine("Elemento mínimo del montículo: " + binomialHeap.GetMinimum());

        binomialHeap.DeleteMinimum();

        Console.WriteLine("Nuevo elemento mínimo del montículo después de la eliminación: " + binomialHeap.GetMinimum());
    }
}
