using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Entity : IEntity
{
    public int ID { get; }
    public double Durability { get; }

    // to finish contr
    protected Entity(int id)
    {
        this.ID = id;
    }


    public double Produce()
    {
        throw new NotImplementedException();
    }

    public void Broke()
    {
        throw new NotImplementedException();
    }
}

