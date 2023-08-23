using System;

namespace TorresDeHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            int numDiscos = 3;
            MoverDiscos(numDiscos, 'A', 'C', 'B');
        }

        static void MoverDiscos(int n, char origen, char destino, char auxiliar)
        {
            if (n == 1)
            {
                Console.WriteLine($"Mover disco 1 desde {origen} hacia {destino}");
                return;
            }

            MoverDiscos(n - 1, origen, auxiliar, destino);
            Console.WriteLine($"Mover disco {n} desde {origen} hacia {destino}");
            MoverDiscos(n - 1, auxiliar, destino, origen);
        }
    }
}
