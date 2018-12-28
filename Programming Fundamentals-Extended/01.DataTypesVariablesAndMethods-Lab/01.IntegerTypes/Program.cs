using System;

namespace _01.IntegerTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            byte firstNumber = byte.Parse(Console.ReadLine());
            uint secondNumber = uint.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());
            long forthNumber = long.Parse(Console.ReadLine());

            Console.WriteLine($"{firstNumber} {secondNumber} {thirdNumber} {forthNumber}");
        }
    }
}