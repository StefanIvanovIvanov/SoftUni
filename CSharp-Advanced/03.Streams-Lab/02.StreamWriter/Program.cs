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
            using (StreamReader streamReader = new StreamReader(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Lab\02.StreamWriter\Program.cs"))
            {
                using (StreamWriter streamWriter = new StreamWriter(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Lab\02.StreamWriter\reversed.txt"))
                {
                    //read the line
                    string line = streamReader.ReadLine();

                    while (line != null)
                    {
                        //reverses the line before writting
                        for (int i = line.Length - 1; i >= 0; i--)
                        {//like Console.ReadLine
                            streamWriter.Write(line[i]);
                        }
                        streamWriter.WriteLine();
                        line = streamReader.ReadLine();
                    }

                }
            }
        }
    }
}
