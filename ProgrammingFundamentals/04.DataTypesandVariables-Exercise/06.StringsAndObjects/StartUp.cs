using System;

namespace _06.StringsAndObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            object obj = s1 + " " + s2;
            string s3 = (string)obj;

            Console.WriteLine(s3);
        }
    }
}