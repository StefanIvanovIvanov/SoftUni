using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader readStream = new StreamReader(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\02.LineNumbers\text.txt"))
            {
                using (StreamWriter writeStream = new StreamWriter(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\02.LineNumbers\output.txt"))
                {
                    string line = readStream.ReadLine();
                    int lineNumber = 1;
                    while (line!=null)
                    {
                        writeStream.WriteLine($"Line {lineNumber}: "+line);
                        lineNumber++;
                        line = readStream.ReadLine();
                    }
                } 
            }
        }
    }
}
