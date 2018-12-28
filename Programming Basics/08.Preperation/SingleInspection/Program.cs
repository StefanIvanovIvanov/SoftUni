using System;

namespace SingleInspection
{
    class Program
    {
        static void Main(string[] args)
        {
            double first = double.Parse(Console.ReadLine());
            double second = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double leftSide = Math.Min(first, second);
            double rightSide = Math.Max(first, second);
            double distanceLeft = Math.Abs(x - leftSide);
            double distanceRight = Math.Abs(x - rightSide);
            double MinDistance = Math.Min(distanceLeft, distanceRight);

            if (leftSide<=x&&x<=rightSide)
            {
                Console.WriteLine("in");
            }
            else { Console.WriteLine("out"); }

            Console.WriteLine(MinDistance);

        }
    }
}