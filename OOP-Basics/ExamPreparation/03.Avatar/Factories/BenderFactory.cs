using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


    public class BenderFactory
    {
        public static Bender Create(List<string> args)
        {
            string type = args[1];
            string name = args[2];
            int power = int.Parse(args[3]);
            double secondaryParameter = double.Parse(args[4]);

            if (type == "Air")
            {
                return new AirBender(name, power, secondaryParameter);
            }else if (type == "Water")
            {
                return new WaterBender(name, power, secondaryParameter);
            }
            else if (type == "Fire")
            {
                return new FireBender(name, power, secondaryParameter);
            }
            else if (type == "Earth")
            {
                return new EarthBender(name, power, secondaryParameter);
            }
            else
            {
               throw new ArgumentException("No such bender");
            }
        }
    }

