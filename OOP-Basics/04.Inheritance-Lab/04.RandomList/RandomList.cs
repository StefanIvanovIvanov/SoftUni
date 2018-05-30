﻿using System;
using System.Collections.Generic;
using System.Text;

public class RandomList : List<string>
{
    Random random = new Random();

    public string RandomString()
    {
        string result = null;
        if (this.Count > 0)
        {
            int randomIndex = random.Next(0, this.Count - 1);
            result = this[randomIndex];
            this.RemoveAt(randomIndex);
        }
        return result;
    }
}

