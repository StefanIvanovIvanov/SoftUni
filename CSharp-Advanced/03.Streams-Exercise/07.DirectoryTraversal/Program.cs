using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();

            var filesDictionary=new Dictionary<string, List<FileInfo>>();

            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var fileInfo=new FileInfo(file);
                string extenstion = fileInfo.Extension;

                if (!filesDictionary.ContainsKey(extenstion))
                {
                    filesDictionary[extenstion]=new List<FileInfo>();
                }

                filesDictionary[extenstion].Add(fileInfo);
            }

            filesDictionary = filesDictionary.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key)
                .ToDictionary(f => f.Key, y => y.Value);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullFileName = desktop + "/report.txt";

            using (var writer = new StreamWriter(fullFileName))
            {
                foreach (var pair in filesDictionary)
                {
                    string extension = pair.Key;
                    writer.WriteLine(extension);
                    var fileInfos = pair.Value.OrderByDescending(f=>f.Length);

                    foreach (var fileInfo in fileInfos)
                    {
                        double fileSize = (double)fileInfo.Length / 1024;
                        writer.WriteLine($"--{fileInfo.Name} - {fileSize:F3}kb");
                    }
                }
            }
        }
    }
}
