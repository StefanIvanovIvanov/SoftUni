using System;
using System.Text;

namespace _03.UnicodeCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

           StringBuilder sb = new StringBuilder();
            foreach (char letter in input)
            {
                sb.Append("\\u" + String.Format("{0:x4}", (int)letter));

            }
            Console.WriteLine(sb);
        }
    }
}