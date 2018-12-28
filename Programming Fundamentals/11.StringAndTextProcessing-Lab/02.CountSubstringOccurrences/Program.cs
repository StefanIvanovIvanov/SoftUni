using System;

namespace _02.CountSubstringOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string str = Console.ReadLine().ToLower();

            int count = 0;
            int index = 0;

            while (true)
            {
                index = text.IndexOf(str, index);
                if (index ==-1)
                {
                    break;
                }
                index++;
                count++;
            }
            Console.WriteLine(count);
        }
    }
}