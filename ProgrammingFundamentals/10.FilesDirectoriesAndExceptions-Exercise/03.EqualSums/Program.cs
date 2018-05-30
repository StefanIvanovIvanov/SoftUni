using System;
using System.IO;
using System.Linq;

namespace _03.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllText("input.txt")
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                int rightSum = 0;
                int leftSum = 0;
                for (int j = 0; j < i; j++)
                {
                    leftSum = leftSum + input[j];
                }
                for (int j = i+1; j < input.Length; j++)
                {
                    rightSum = rightSum + input[j];
                }
                if (leftSum == rightSum)
                {
                    File.WriteAllText("output.txt", i.ToString());
                    return;
                }
            }
            File.WriteAllText("output.txt", "no");
        }
    }
}