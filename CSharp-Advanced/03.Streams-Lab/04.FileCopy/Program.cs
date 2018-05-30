using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream source =
                new FileStream(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Lab\04.FileCopy\stream.jpg", FileMode.Open))
            {
                using (FileStream destination = new FileStream(@"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Lab\04.FileCopy\stream-copy.jpg", FileMode.Create))
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                            break;
                        destination.Write(buffer, 0, buffer.Length);
                    }
            }
        }
    }
}
