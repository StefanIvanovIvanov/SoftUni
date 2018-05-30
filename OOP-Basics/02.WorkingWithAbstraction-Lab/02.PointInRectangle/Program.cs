using System;
using System.Collections.Generic;
using System.Linq;

namespace PointInTrinagle
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(Console.ReadLine());
            int pointsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pointsCount; i++)
            {
                Point point = new Point(Console.ReadLine);
                bool containsPoint = rectangle.Containt(point);
                Console.WriteLine(containsPoint);
            }
        }
    }
}
