using System;
using System.Linq;

namespace _05.MagicExchangeableWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string first = input[0];
            string second = input[1];

            char[] firstWordArray = first.ToCharArray().Distinct().ToArray();
            char[] secondWordArray = second.ToCharArray().Distinct().ToArray();
            if (firstWordArray.Length == secondWordArray.Length)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}