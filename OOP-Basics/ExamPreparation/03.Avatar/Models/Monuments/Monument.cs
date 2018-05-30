using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Monument
{
    private string name;

    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    public virtual string ToString()
    {
        return "";
    }

    public virtual int Affinity { get; set; }
}

