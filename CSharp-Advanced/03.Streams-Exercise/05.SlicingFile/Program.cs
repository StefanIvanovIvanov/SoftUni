using System;
using System.Collections.Generic;
using System.IO;

namespace SlicingFile
{
    public static class Program
    {
        private const int bufferSize = 4096;
        public static void Main(string[] args)
        {
            string sourceFile = @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\05.SlicingFile\sliceMe.mp4";
            string destination = @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\05.SlicingFile\";
            int parts = 5;
            Slice(sourceFile, destination, parts);
            var files = new List<string>
            {
                @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\05.SlicingFile\Part-0.mp4",
                @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\05.SlicingFile\Part-1.mp4",
                @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\05.SlicingFile\Part-2.mp4",
                @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\05.SlicingFile\Part-3.mp4",
                @"D:\SoftUni\C# Advanced\Упражнения\03.Streams-Exercise\05.SlicingFile\Part-4.mp4",
            };
             Assemble(files, destination);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
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
                    string currentPart = destinationDirectory + $"Part-{i}.{extension}";

                    using (FileStream writer = new FileStream(currentPart, FileMode.Create))
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

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Substring(files[0].LastIndexOf('.') + 1);

            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = "./";
            }
            if (!destinationDirectory.EndsWith("/"))
            {
                destinationDirectory += "/";
            }
            string assemblesFile = $"{destinationDirectory}Assembled.{extension}";
            using (FileStream writer = new FileStream(assemblesFile, FileMode.Create))
            {
                byte[] bufffer = new byte[4096];
                foreach (var file in files)
                {
                    using (FileStream reader = new FileStream(file, FileMode.Open))
                    {
                        while (reader.Read(bufffer, 0, bufferSize) == bufferSize)
                        {
                            writer.Write(bufffer, 0, bufferSize);
                        }
                    }
                }
            }
        }
    }
}