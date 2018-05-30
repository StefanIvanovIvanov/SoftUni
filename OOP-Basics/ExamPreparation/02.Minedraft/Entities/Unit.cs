using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Unit
{
    protected Unit(string id)
    {
        this.Id = id;
    }

    public string Id { get; }
}