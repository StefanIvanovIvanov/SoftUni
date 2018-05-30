using System;

namespace _14.IntegerТoHexАndBinary
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string binary = Convert.ToString(number, 2).ToUpper();
            string hex = Convert.ToString(number, 16).ToUpper();

            Console.WriteLine(hex);
            Console.WriteLine(binary);
        }
    }
}