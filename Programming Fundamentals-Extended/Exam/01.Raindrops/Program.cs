using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Raindrops
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double density = double.Parse(Console.ReadLine());
            double sum = 0;
            bool isZero = true;
            for (int i = 0; i < n; i++)
            {
                double[] tokens = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                    .ToArray();

                double raindropsCount = tokens[0];
                double squareMeters = tokens[1];

                double regionalCoefficient = raindropsCount / squareMeters;
                sum += regionalCoefficient;
            }
            if (density!=0)
            {
                double result = sum / density;
                Console.WriteLine($"{result:f3}");
            }
            else
            {
                Console.WriteLine($"{sum:f3}");
            }
        }
    }
}
