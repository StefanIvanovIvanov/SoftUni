﻿using System;

namespace _09.ReverseCharacters
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char char1 = char.Parse(Console.ReadLine());
            char char2 = char.Parse(Console.ReadLine());
            char char3 = char.Parse(Console.ReadLine());

            Console.WriteLine($"{char3}{char2}{char1}");
        }
    }
}