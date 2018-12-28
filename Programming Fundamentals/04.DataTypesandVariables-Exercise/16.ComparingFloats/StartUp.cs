using System;

namespace _16.ComparingFloats
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double biggerNumber = Math.Max(a, b);
            double smallerNumber = Math.Min(a, b);
            double difference = biggerNumber - smallerNumber;

            bool check = difference< 0.000001;

            Console.WriteLine(check);
        }
    }
}