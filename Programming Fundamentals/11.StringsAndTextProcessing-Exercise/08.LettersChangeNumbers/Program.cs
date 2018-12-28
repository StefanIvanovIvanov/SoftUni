using System;
using System.Linq;

namespace _08.LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] strings = input.Split(new string[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
            double result = 0;

            foreach (var item in strings)
            {
                char firstLetter = item[0];
                char lastLetter = item[item.Length - 1];
                double num = int.Parse(item.Substring(1, item.Length - 2));

                if (!char.IsUpper(firstLetter))
                {
                    num *= (firstLetter - 96);
                }
                else
                {

                    num /= (firstLetter - 64);
                }

                if (char.IsUpper(lastLetter))
                {
                    num -= lastLetter - 64;
                }
                else
                {
                    num += lastLetter - 96;
                }

                result += num;
            }

            Console.WriteLine("{0:f2}", result);

        }
    }
}