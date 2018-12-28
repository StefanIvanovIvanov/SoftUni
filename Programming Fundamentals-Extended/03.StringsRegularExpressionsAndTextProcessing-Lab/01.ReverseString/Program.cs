using System;
using System.Linq;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            char[] result = str.ToCharArray();
            Array.Reverse(result);
            Console.WriteLine(string.Join("",result));
        }
    }
}