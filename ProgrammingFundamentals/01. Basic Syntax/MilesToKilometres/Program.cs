using System;

namespace MilesToKilometres
{
    class Program
    {
        static void Main(string[] args)
        {
            double miles = double.Parse(Console.ReadLine());

            double kilometres = miles * 1.60934;

            Console.WriteLine($"{kilometres:f2}");
        }
    }
}