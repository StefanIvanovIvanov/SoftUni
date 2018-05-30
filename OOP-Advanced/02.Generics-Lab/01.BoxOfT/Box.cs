using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Box<T>
{
    private List<T> data;

    public Box()
    {
        this.data = new List<T>();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove()
    {
        var toRemove = this.data.Last();
        this.data.RemoveAt(this.data.Count - 1);
        return toRemove;
    }

    public int Count => this.data.Count;
}

