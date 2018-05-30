using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class EnergyRepository:IEnergyRepository
    {
        public double EnergyStored { get; }
        public bool TakeEnergy(double energyNeeded)
        {
            throw new NotImplementedException();
        }

        public void StoreEnergy(double energy)
        {
            throw new NotImplementedException();
        }
    }

