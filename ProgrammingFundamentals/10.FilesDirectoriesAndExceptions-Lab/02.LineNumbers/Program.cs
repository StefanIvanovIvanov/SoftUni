using System;
using System.Collections.Generic;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            List<string>orderedLines=new List<string>();
            int lineNumber = 1;
            foreach (var line in lines)
            {
                string newLine = $"{lineNumber}. " + line;
                orderedLines.Add(newLine);
                lineNumber++;
            }
            File.WriteAllLines("new", orderedLines);
        }
    }
}