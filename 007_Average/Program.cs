using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NumberAverageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = new List<double>();
            do
            {
                Console.Write("Enter a number (or any non-numeric value to quit): ");
                string numberString = Console.ReadLine();

                if (!double.TryParse(numberString, NumberStyles.Float,
                    new NumberFormatInfo(), out double number))
                {
                    break;
                }

                numbers.Add(number);
                double average = numbers.Average();
                Console.WriteLine($"The average value: {average:F2}");
            }
            while (true);
        }
    }
}
