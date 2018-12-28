using System;

namespace _06.CalculateTriangleArea
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double area = CalculateTriangleArea(a, b);
            Console.WriteLine(area);
        }

        static double CalculateTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}