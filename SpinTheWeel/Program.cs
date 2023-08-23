// CircularLinkedList<string> categories =  new CircularLinkedList<string>(); 
// categories.AddLast("Sport"); 
// categories.AddLast("Culture"); 
// categories.AddLast("History"); 
// categories.AddLast("Geography"); 
// categories.AddLast("People"); 
// categories.AddLast("Technology"); 
// categories.AddLast("Nature"); 
// categories.AddLast("Science"); 

// Random random = new Random(); 
// int totalTime = 0; 
// int remainingTime = 0; 
// foreach (string category in categories) 
// { 
//     if (remainingTime <= 0) 
//     { 
//         Console.WriteLine("Press [Enter] to start or any other to exit."); 
//         switch (Console.ReadKey().Key) 
//         { 
//             case ConsoleKey.Enter: 
//                 totalTime = random.Next(1000, 5000); 
//                 remainingTime = totalTime; 
//                 break; 
//             default: 
//                 return; 
//         } 
//     } 
 
//     int categoryTime = (-450 * remainingTime) / (totalTime - 50) + 500 + (22500 / (totalTime - 50)); 
//     remainingTime -= categoryTime; 
//     Thread.Sleep(categoryTime); 
 
//     Console.ForegroundColor = remainingTime <= 0 ? ConsoleColor.Red : ConsoleColor.Gray; 
//     Console.WriteLine(category);
//     Console.ForegroundColor = ConsoleColor.Gray; 
// } 

using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        CircularLinkedList<string> categories =
            new CircularLinkedList<string>();
        categories.AddLast("Sport");
        categories.AddLast("Culture");
        categories.AddLast("History");
        categories.AddLast("Geography");
        categories.AddLast("People");
        categories.AddLast("Technology");
        categories.AddLast("Nature");
        categories.AddLast("Science");

        Random random = new Random();
        int totalTime = 0;
        int remainingTime = 0;

        foreach (string category in categories)
        {
            if (remainingTime <= 0)
            {
                Console.WriteLine("Press [Enter] to start " +
                    "or any other key to exit.");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    totalTime = random.Next(1000, 5000);
                    remainingTime = totalTime;
                }
                else
                {
                    return;
                }
            }

            int categoryTime = (-450 * remainingTime) / (totalTime - 50)
                + 500 + (22500 / (totalTime - 50));
            remainingTime -= categoryTime;
            Thread.Sleep(categoryTime);

            Console.ForegroundColor = remainingTime <= 0
                ? ConsoleColor.Red : ConsoleColor.Gray;
            Console.WriteLine(category);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

public class CircularLinkedList<T> : LinkedList<T>
{
    public new IEnumerator<T> GetEnumerator()
    {
        if (this.Count == 0)
            yield break;

        var current = First;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next ?? First;
        }
    }
}
