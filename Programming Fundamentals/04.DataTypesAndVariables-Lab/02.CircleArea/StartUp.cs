using System;

namespace _02.CircleArea
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());

            double area = r * r * Math.PI;
            Console.WriteLine($"{area:f12}");
        }
    }
}