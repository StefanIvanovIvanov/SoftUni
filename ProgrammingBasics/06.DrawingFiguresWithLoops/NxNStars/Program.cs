﻿using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i<=n; i++)
            {
                Console.Write(new string('*', n));
                Console.WriteLine();
            }
        }
    }
}