using System;

namespace _01.HelloName_
{
    class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Console.WriteLine(GetName(input));
        }

        static string GetName(string name)
        {
            string print = $"Hello, {name}!";
            return print;
        }
    }
}