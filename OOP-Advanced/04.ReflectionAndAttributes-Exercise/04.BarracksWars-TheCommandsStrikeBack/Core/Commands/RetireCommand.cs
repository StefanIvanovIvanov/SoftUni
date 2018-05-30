using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Contracts
{
    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            try
            {
                string unitType = Data[1];
                this.Repository.RemoveUnit(unitType);
                return $"{unitType} retired!";
            }
            catch (Exception e)
            {
                throw new ArgumentException("No such units in repository.", e);
            }
            

        }
    }
}
