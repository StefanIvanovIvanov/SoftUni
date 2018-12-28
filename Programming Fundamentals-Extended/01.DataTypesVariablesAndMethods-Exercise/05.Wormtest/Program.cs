using System;

namespace _05.Wormtest
{
    class Program
    {
        static void Main(string[] args)
        {
            long l = long.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            long length = l * 100;

            double remainder = length % width;

            if (remainder != 0&&width!=0)
            {
                double percent = (length / width) * 100;
                Console.WriteLine("{0:f2}%", percent);
            }
            else
            {
                double product = length * width;
                Console.WriteLine("{0:f2}", product);
            }
        }
    }
}