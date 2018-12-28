using System;

namespace _02.CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();
            int count = 0;
            int index = -1;
            pattern = pattern.ToLower();
            while (true)
            {
                text = text.ToLower();
                index = text.IndexOf(pattern, index + 1);
                if (index == -1)
                {
                    break;
                }
                count++;
            }
            Console.WriteLine(count);
        }
    }
}