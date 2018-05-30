using System;

namespace _08.CenterPoint
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double firstDistance = Calculate(x1, y1);
            double secondDistance = Calculate(x2, y2);
            if (firstDistance < secondDistance)
                Console.WriteLine($"({x1}, {y1})");
            else Console.WriteLine($"({x2}, {y2})");
  
        }
        public static double Calculate(double x, double y)
        {
            double point = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
            return point;
        }
    }
}