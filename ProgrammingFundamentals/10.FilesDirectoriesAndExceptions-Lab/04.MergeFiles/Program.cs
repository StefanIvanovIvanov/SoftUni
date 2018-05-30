using System;
using System.Collections.Generic;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] file1 = File.ReadAllText("FileOne.txt").Split();
            string[] file2 = File.ReadAllText("FileTwo.txt").Split('\r', '\n');


            File.WriteAllText("result.txt", "");

            for (int i = 0; i < file1.Length; i++)
            {
                File.AppendAllText("result.txt", file1[i]+Environment.NewLine+ file2[i]);
            }
        }
    }
}