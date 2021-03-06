﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ListyIterator<T> : IEnumerable
{
    private List<T> data;
    private int internalIndex;

    public ListyIterator(params T[] data)
    {
        this.internalIndex = 0;
        this.data = new List<T>(data);
    }

    public bool HasNext()
    {
        bool result = internalIndex < this.data.Count - 1;
        return result;
    }

    public bool Move()
    {
        if (!HasNext())
        {
            return false;
        }
        this.internalIndex++;
        return true;
    }

    public void Print()
    {
        if (!this.data.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(this.data[internalIndex]);
    }

    public void PrintAll()
    {
        if (!this.data.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(string.Join(" ", this.data));
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int index = 0; index < this.data.Count; index++)
        {
            yield return this.data[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

