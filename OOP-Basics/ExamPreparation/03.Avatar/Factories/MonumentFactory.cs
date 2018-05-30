using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MonumentFactory
{
    public static Monument Create(List<string>args)
    {
        string type = args[1];
        string name = args[2];
        int affinity = int.Parse(args[3]);

        if (type == "Air")
        {
            return new AirMonument(name, affinity);
        }
        else if (type == "Water")
        {
            return new WaterMonument(name, affinity);
        }
        else if (type == "Fire")
        {
            return new FireMonument(name, affinity);
        }
        else if (type == "Earth")
        {
            return new EarthMonument(name, affinity);
        }
        else
        {
            throw new ArgumentException("No such monument");
        }
    }
}
