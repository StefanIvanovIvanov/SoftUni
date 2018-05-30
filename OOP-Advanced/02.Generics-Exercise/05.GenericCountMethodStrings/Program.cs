using System;
using System.Collections.Generic;


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
        string toCompare = Console.ReadLine();

        Console.WriteLine(box.CompareTo(toCompare));
    }
}

