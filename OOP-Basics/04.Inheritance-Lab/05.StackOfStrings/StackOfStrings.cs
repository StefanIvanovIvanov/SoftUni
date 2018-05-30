using System;
using System.Collections.Generic;
using System.Text;


public class StackOfStrings
{
    List<string> data = new List<string>();
    public void Push(string item)
    {
        data.Add(item);
    }

    public string Peek()
    {
        string result = null;
        if (!IsEmpty())
        {
            int index = data.Count - 1;
            result = data[index];

        }
        return result;
    }

    public string Pop()
    {
        string result = null;
        if (!IsEmpty())
        {
            int index = data.Count - 1;
            result = data[index];
            data.RemoveAt(index);
        }
        return result;
    }

    public bool IsEmpty()
    {
        if (data.Count == 0)
        {
            return true;
        }
        return false;
    }
}

