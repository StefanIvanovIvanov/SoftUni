using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class PressureProvider:Provider
    {
        private const int durabilityDecreasement = 300;
        private const int energyMultiplier = 2;

        public PressureProvider(int id, double energyOutput) 
        : base(id, energyOutput)
        {
            this.Durability -= durabilityDecreasement;
            this.EnergyOutput *= energyMultiplier;
        }
    }

