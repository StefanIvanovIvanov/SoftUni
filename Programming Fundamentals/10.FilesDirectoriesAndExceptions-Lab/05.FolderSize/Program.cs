using System;
using System.IO;

namespace _05.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] folder = Directory.GetFiles("TestFolder");
            double sum = 0;

            foreach (string file in folder)
            {
                FileInfo info = new FileInfo(file);
                sum = sum + info.Length;
            }
            sum = sum / 1024 / 1024;
            File.WriteAllText("output.txt", sum.ToString());
        }
    }
}