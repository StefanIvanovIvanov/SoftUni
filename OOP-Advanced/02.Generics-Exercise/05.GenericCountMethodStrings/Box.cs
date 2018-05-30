using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>:IComparable<string>
{
    public readonly List<string> list;

    public Box(IEnumerable<string> list)
    {
        this.list = new List<string>(list);
    }
    

    public int CompareTo(string toCompare)
    {
        int counter = 0;
        foreach (string line in this.list)
        {
            if (line.CompareTo(toCompare) > 0)
            {
                counter++;
            }
        }
        return counter;
    }
}

