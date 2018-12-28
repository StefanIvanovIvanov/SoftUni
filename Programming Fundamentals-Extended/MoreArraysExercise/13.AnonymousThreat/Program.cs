using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> data = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();
            while (input != "3:1")
            {
                string[] arrgs = input.Split().ToArray();

                string command = arrgs[0];

                if (command == "merge")
                {
                    int startIndex = int.Parse(arrgs[1]);
                    int endIndex = int.Parse(arrgs[2]);

                    if (endIndex >= data.Count)
                    {
                        endIndex = data.Count - 1;
                    }
                    if (startIndex >= data.Count)
                    {
                        startIndex= data.Count - 1;
                    }
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex < 0)
                    {
                        endIndex = 0;
                    }
                    StringBuilder sb = new StringBuilder();

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        sb.Append(data[i]);
                    }
                    int count = endIndex - startIndex;
                    while (startIndex + count >= data.Count)
                    {
                        count--;
                    }
                    data.RemoveRange(startIndex, count+1);
                    data.Insert(startIndex, sb.ToString());
                    sb.Clear();
                }
                if (command == "divide")
                {
                    int index = int.Parse(arrgs[1]);
                    int partitions = int.Parse(arrgs[2]);

                    string element = data[index];

                    List<string> dividedElement=new List<string>();

                    int length = element.Length / partitions;

                    for (int i = 0; i < partitions; i++)
                    {
                        string newElement = null;
                        if (i == partitions - 1)
                        {
                             newElement = element.Substring(i * length);
                        }
                        else
                        {
                             newElement = element.Substring(i * length, length);
                        }
                        dividedElement.Add(newElement);
                    }
                    data.RemoveAt(index);
                    data.InsertRange(index, dividedElement);
                    dividedElement.Clear();
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", data));
        }
    }
}