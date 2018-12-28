using System;

namespace PointInTheFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            if ((4 <= x && x <= 10 && -5 <= y && y <= 3) || ((2 <= x && x <= 12 && -3 <= y && y <= 1)))
            {
                Console.WriteLine("in");
            }
            else Console.WriteLine("out");
        }
    }
}