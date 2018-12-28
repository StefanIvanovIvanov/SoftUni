using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt").ToArray();
            Dictionary<string,int>result=new Dictionary<string, int>();

            for (int i = 0; i < input.Length; i+=2)
            {
                if (input[i] == "stop" || input[i + 1] == "stop")
                {
                    break;
                }
                string materials = input[i];
                int quantity = int.Parse(input[i + 1]);

                if (result.ContainsKey(materials))
                {
                    materials += quantity;
                }
                else
                {
                    result.Add(materials, quantity);
                }
            }
            foreach (KeyValuePair<string, int> pairs in result)
            {
                File.AppendAllText("output.txt", $"{pairs.Key} -> {pairs.Value}"+Environment.NewLine);
            }


        }
    }
}
           