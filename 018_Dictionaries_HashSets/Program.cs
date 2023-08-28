using System;
using System.Collections.Generic;

namespace EjemploHashSetCompleto
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear un HashSet de strings
            HashSet<string> colores = new HashSet<string>();

            // Agregar elementos al HashSet
            colores.Add("Rojo");
            colores.Add("Verde");
            colores.Add("Azul");

            Console.WriteLine("HashSet después de agregar elementos:");
            ImprimirHashSet(colores);

            // Comprobar si un elemento está en el HashSet
            Console.WriteLine("¿Contiene 'Rojo'? " + colores.Contains("Rojo"));
            Console.WriteLine("¿Contiene 'Amarillo'? " + colores.Contains("Amarillo"));

            // Eliminar un elemento del HashSet
            colores.Remove("Verde");

            Console.WriteLine("HashSet después de eliminar 'Verde':");
            ImprimirHashSet(colores);

            // Crear otro HashSet de strings
            HashSet<string> coloresSecundarios = new HashSet<string>
            {
                "Amarillo",
                "Naranja",
                "Verde"
            };

            // Unión de dos HashSets
            colores.UnionWith(coloresSecundarios);

            Console.WriteLine("HashSet después de la unión:");
            ImprimirHashSet(colores);

            // Intersección de dos HashSets
            colores.IntersectWith(coloresSecundarios);

            Console.WriteLine("HashSet después de la intersección:");
            ImprimirHashSet(colores);

            Console.ReadLine();
        }

        static void ImprimirHashSet<T>(HashSet<T> hashSet)
        {
            foreach (var elemento in hashSet)
            {
                Console.WriteLine(elemento);
            }
            Console.WriteLine();
        }
    }
}
