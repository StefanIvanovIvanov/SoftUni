using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Lake : IEnumerable<int>
{
    public List<int> stones;

    public Lake(List<int> stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Count; i += 2)
        {
            yield return this.stones[i];
        }
        int lastIdex = this.stones.Count % 2 == 0 ? this.stones.Count - 1 : this.stones.Count - 2;
        for (int i = lastIdex; i >= 1; i -= 2)
        {
            yield return this.stones[i];
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

