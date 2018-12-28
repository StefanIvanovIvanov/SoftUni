using System;

namespace Greatest_Common_Divisor
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            while (b != 0)
            {
                int newNumber = b;
                b = a % b;
                a = newNumber;
            }
            Console.WriteLine(a);
        }
    }
}