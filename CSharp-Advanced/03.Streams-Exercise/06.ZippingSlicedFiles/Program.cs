using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ZippingSlicedFiles
{
    class Program
    {
        
        private const int bufferSize = 4096;
        public static void Main(string[] args)
        {
            string sourceFile = @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\05.SlicingFile\sliceMe.mp4";
            string destination = @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\06.ZippingSlicedFiles\";
            int parts = 5;
            Zip(sourceFile, destination, parts);        
        }

        static void Zip(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream reader = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);
                long pieceSize = (long)Math.Ceiling((double)reader.Length / parts);

                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    if (destinationDirectory == string.Empty)
                    {
                        destinationDirectory = "./";
                    }
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}.gz";

                    using (GZipStream writer = new GZipStream(new FileStream(currentPart, FileMode.Create), CompressionLevel.Optimal))
                    {
                        byte[] buffer = new byte[bufferSize];
                        while (reader.Read(buffer, 0, buffer.Length) == bufferSize)
                        {
                            writer.Write(buffer, 0, bufferSize);
                            currentPieceSize += bufferSize;
                            if (currentPieceSize >= pieceSize)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }     
    }
}
