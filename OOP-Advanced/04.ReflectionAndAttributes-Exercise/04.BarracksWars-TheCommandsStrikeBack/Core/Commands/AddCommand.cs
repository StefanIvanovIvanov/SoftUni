﻿using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Models.Units;

namespace _03BarracksFactory.Contracts
{
   public class AddCommand:Command
    {
        public AddCommand(string[] data, IRepository repository, IUnitFactory unitFactory) 
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
