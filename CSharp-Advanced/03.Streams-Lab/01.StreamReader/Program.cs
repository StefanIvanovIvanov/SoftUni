using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Stream
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Lab\01.StreamReader\Program.cs");
            using (stream)
            {
                int lineNumber = 0;
                string line = stream.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    Console.WriteLine($"Line {lineNumber}: " + line);
                    line = stream.ReadLine();

                }
            }
        }
    }
}
