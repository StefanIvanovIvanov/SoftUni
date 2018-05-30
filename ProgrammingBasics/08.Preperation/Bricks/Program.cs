using System;

namespace Bricks
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = int.Parse(Console.ReadLine());
            double w = int.Parse(Console.ReadLine());
            double m = int.Parse(Console.ReadLine());

            double course = w * m;
            double result = Math.Ceiling( x / course);

            Console.WriteLine(result);
        }
    }
}