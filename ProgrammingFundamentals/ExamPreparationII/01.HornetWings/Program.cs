using System;

namespace HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            double distanceTraceled = (n / 1000) * m;
            int time = n / 100;
            int rests = n / p * 5;

            decimal result = rests + time;

            Console.WriteLine($"{distanceTraceled:f2} m.");
            Console.WriteLine($"{result} s.");
        }
    }
}