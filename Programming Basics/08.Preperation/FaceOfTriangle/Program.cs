using System;

namespace _08.Preperation
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());

            double length = x3 - x2;
            double height = y2 - y1;

            double h = Math.Abs((length * height) / 2);
            Console.WriteLine(h);
        }
    }
}