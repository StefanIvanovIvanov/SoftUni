using System;
using System.Collections.Generic;


public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<double> list = new List<double>();
        for (int i = 0; i < n; i++)
        {
            list.Add(double.Parse(Console.ReadLine()));
        }

        var box = new Box<double>(list);
        double toCompare = double.Parse(Console.ReadLine());

        Console.WriteLine(box.CompareTo(toCompare));
    }
}

