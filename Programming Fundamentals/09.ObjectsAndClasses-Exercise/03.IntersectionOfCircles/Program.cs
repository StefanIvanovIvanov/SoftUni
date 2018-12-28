using System;
using System.Linq;

namespace _03.IntersectionOfCircles
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle1 = ReadCircle();
            Circle circle2 = ReadCircle();

            double distance = GetDistance(circle1.point, circle2.point);
            if (distance <= circle1.R + circle2.R)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static Circle ReadCircle()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Point point = new Point() { X = input[0], Y = input[1] };
            Circle circle = new Circle() { point = point, R = input[2] };
            return circle;

        }

        static double GetDistance(Point point1, Point point2)
        {
            double distance = Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
            return distance;
        }
    }

    public class Circle
    {
        public Point point { get; set; }
        public int R { get; set; }
    }
  public  class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}