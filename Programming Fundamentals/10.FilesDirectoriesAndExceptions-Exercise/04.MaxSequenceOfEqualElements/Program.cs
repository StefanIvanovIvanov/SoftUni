using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllText("input.txt")
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            List<int> bestSequence = new List<int>();

            int count = 0;
            int bestCount = 0;
            int start = 0;

            for (int i = 0; i < input.Length-1; i++)
            {
                if (0 < i)
                {
                    if (input[i + 1] == input[i])
                    {
                        count++;
                        if (count > bestCount)
                        {
                            bestCount = count;
                            start = i - count;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            for (int i = start+1; i <=start+bestCount+1; i++)
            {
                File.AppendAllText("output.txt", input[i]+ " ");
            }
        }
    }
}