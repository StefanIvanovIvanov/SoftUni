using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            string[] oddList = lines.Where((line, i) => i % 2 == 1).ToArray();
            File.WriteAllLines("new.txt", oddList);        
        }
    }
}