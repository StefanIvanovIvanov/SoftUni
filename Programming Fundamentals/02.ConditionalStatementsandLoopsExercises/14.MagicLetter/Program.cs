using System;

namespace _14.MagicLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            string skip = Console.ReadLine();

            for (char i = firstLetter; i <= secondLetter; i++)
            {
                for (char j = firstLetter; j <= secondLetter; j++)
                {
                    for (char k = firstLetter; k <= secondLetter; k++)
                    {
                        string combo = $"{i}{j}{k} ";
                        if (!combo.Contains(skip))
                        {
                            Console.Write(combo);
                        }
                    }
                }
            }

        }
    }
}