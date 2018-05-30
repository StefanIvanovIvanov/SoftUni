using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
{
    public readonly List<int> list;

    public Box(IEnumerable<int> list)
    {
        this.list = new List<int>(list);
    }

    public void Swap(int firstIndex, int secondIndex)
    {
        int remember = this.list[firstIndex];
        this.list[firstIndex] = this.list[secondIndex];
        this.list[secondIndex] = remember;
    }
}

