using System;

namespace _08.GreaterOfTwoValues
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var type = Console.ReadLine();

            if (type == "int")
            {
                int firstInput = int.Parse(Console.ReadLine());
                int secondInput = int.Parse(Console.ReadLine());
                var max = GetResult(firstInput, secondInput);
                Console.WriteLine(max);
            }
            else if (type == "char")
            {
                char firstInput = char.Parse(Console.ReadLine());
                char secondInput = char.Parse(Console.ReadLine());
                var max = GetResult(firstInput, secondInput);
                Console.WriteLine(max);
            }
            else if (type == "string")
            {
                string firstInput = Console.ReadLine();
                string secondInput = Console.ReadLine();
                var max = GetResult(firstInput, secondInput);
                Console.WriteLine(max);
            }
        }

        static int GetResult(int intA,int intB)
        {
            int larger = 0;
            if (intA >= intB)
            {
                larger = intA;
            }
            else
            {
                larger = intB;
            }
            return larger;
        }

        static char GetResult(char charA, char charB)
        {
            char larger = (char)0x00;
            if (charA >= charB)
            {
                larger = charA;
            }
            else
            {
                larger = charB;
            }
            return larger;
        }

        static string GetResult(string stringA, string stringB)
        {
            string larger = null;
            if (stringA.CompareTo(stringB) >= 0)
            {
                larger = stringA;
            }
            else
            {
                larger = stringB;
            }
            return larger;
        }
    }
}