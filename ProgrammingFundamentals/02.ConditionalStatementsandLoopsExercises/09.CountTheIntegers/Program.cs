using System;

namespace _09.CountTheIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            try
            {
                while (true)
                {
                    int number = int.Parse(Console.ReadLine());
                    sum++;
                }
            }
            catch
            { Console.WriteLine(sum); }
        }
    }
}