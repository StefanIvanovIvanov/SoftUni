using System;

namespace _02.HornetWings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double m = double.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());

            double distance = (n / 1000) * m;
            Console.WriteLine("{0:f2} m.", distance);

            int seconds = n / 100;
            int rests = (n / p) * 5;
            int totalTime = seconds + rests;
            Console.WriteLine("{0} s.", totalTime);
        }
    }
}