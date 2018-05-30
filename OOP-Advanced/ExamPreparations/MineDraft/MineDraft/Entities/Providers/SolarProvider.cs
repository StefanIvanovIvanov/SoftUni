using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class SolarProvider:Provider
    {
        private const int durabilityIncresement = 500;
        public SolarProvider(int id, double energyOutput)
        : base(id, energyOutput)
        {
            this.Durability += durabilityIncresement;
        }
    }

