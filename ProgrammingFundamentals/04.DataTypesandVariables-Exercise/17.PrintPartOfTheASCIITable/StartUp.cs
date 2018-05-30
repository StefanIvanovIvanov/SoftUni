using System;

namespace _17.PrintPartOfTheASCIITable
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            for (int i = number1; i <= number2; i++)
            {
                char character = (char)i;
                Console.Write(character+ " ");
            }
        }
    }
}