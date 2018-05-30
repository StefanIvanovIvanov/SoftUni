using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CommandInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arr = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x=>x.Trim())
                .ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {

                string[] arrgs = command
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string comm = arrgs[0];
                if (comm == "reverse")
                {
                    int start = int.Parse(arrgs[2]);
                    int count = int.Parse(arrgs[4]);
                    if (start >= 0 && start <= arr.Count && count >= 0 && count <= arr.Count)
                    {
                        arr.Reverse(start, count);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (comm == "sort")
                {
                    int start = int.Parse(arrgs[2]);
                    int count = int.Parse(arrgs[4]);
                    if (start >= 0 && start <= arr.Count && count >= 0 && count <= arr.Count)
                    {
                        List<string> sortedArray = new List<string>();
                        for (int i = start; i < start + count; i++)
                        {
                            sortedArray.Add(arr[i]);
                        }
                        sortedArray=sortedArray.OrderBy(x=>x).ToList();
                        arr.RemoveRange(start, count);
                        arr.InsertRange(start, sortedArray);
                        sortedArray.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                }
                else if (comm == "rollLeft")
                {
                    int count = int.Parse(arrgs[1]);

                    for (int j = 0; j < count % arr.Count; j++)
                    {
                        string remember = arr[0];
                        for (int k = 0; k < arr.Count - 1; k++)
                        {
                            arr[k] = arr[k + 1];
                        }
                        arr[arr.Count - 1] = remember;
                    }
                }
                else if (comm == "rollRight")
                {
                    int count = int.Parse(arrgs[1]);

                    for (int j = 0; j < count % arr.Count; j++)
                    {
                        string remember = arr[arr.Count - 1];
                        for (int k = arr.Count - 1; k > 0; k--)
                        {
                            arr[k] = arr[k - 1];
                        }
                        arr[0] = remember;
                    }
                    
                }
                command = Console.ReadLine();
            }
            Console.Write("[");
            Console.Write(string.Join(", ", arr));
            Console.WriteLine("]");
        }
    }
}