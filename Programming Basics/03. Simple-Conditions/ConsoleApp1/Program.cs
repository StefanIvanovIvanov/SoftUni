﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            double entry = double.Parse(Console.ReadLine());
            if (entry >= 5.50) { Console.WriteLine("Excellent!"); }
        }
    }
}
