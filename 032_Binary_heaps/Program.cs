using System;
using System.Collections.Generic;
using PommaLabs.Hippie;

namespace HeapSortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejemplo de ordenación por montículo
            List<int> desordenado = new List<int>() { 50, 33, 78, -23, 90, 41 };
            var monticulo = new MinHeap<int>(); // Utiliza MinHeap de PommaLabs.Hippie

            desordenado.ForEach(i => monticulo.Add(i));
            Console.WriteLine("Desordenado: " + string.Join(", ", desordenado));

            List<int> ordenado = new List<int>(monticulo.Count);
            while (monticulo.Count > 0)
            {
                ordenado.Add(monticulo.ExtractMin());
            }
            Console.WriteLine("Ordenado: " + string.Join(", ", ordenado));

            // Ejemplo de uso de montículo para una cola de prioridad
            var colaDePrioridad = new MinHeap<int>(); // Utiliza MinHeap para cola de prioridad

            colaDePrioridad.Add(10);
            colaDePrioridad.Add(30);
            colaDePrioridad.Add(20);
            colaDePrioridad.Add(5);

            Console.WriteLine("Elemento de mayor prioridad: " + colaDePrioridad.PeekMin());

            colaDePrioridad.ExtractMin(); // Removemos el elemento de mayor prioridad
            Console.WriteLine("Elemento de mayor prioridad después de la eliminación: " + colaDePrioridad.PeekMin());
        }
    }
}
