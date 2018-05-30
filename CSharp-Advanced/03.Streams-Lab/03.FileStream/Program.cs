using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "test";

            System.IO.FileStream stream = null;

            try
            {
                stream = new System.IO.FileStream(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Lab\03.FileStream\log.txt", FileMode.Create);
                var bytes = System.Text.Encoding.UTF8.GetBytes(text);
                stream.Write(bytes, 0, text.Length);
            }
            finally
            {
                stream.Close();
            }
        }
    }
}
