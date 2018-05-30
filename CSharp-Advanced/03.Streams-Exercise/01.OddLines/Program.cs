using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader stream = new StreamReader(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\01.OddLines\text.txt"))
            {
                string line = stream.ReadLine();
                int lineNumber = 0;
                while (line!=null)
                {
                    if (lineNumber % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    lineNumber++;
                    line = stream.ReadLine();
                }
            }
        }
    }
}
