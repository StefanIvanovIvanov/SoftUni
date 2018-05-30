using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<string> list = new List<string>();
        for (int i = 0; i < n; i++)
        {
            list.Add(Console.ReadLine());
        }

        var box = new Box<string>(list);

        int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

        box.Swap(indexes[0], indexes[1]);

        foreach (var line in box.list)
        {
            Console.WriteLine($"{line.GetType().FullName}: {line}");
        }
    }
}

