using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
{
    public readonly List<double> list;

    public Box(IEnumerable<double> list)
    {
        this.list = new List<double>(list);
    }


    public int CompareTo(double toCompare)
    {
        int counter = 0;
        foreach (double line in this.list)
        {
            if (line > toCompare)
            {
                counter++;
            }
        }
        return counter;
    }
}

