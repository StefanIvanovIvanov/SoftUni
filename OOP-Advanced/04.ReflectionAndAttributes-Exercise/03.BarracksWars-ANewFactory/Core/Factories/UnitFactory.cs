using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
           // Type type = Type.GetType("_03BarracksFactory.Models.Units." + unitType);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            if (model == null)
            {
                throw new ArgumentException("Invalid Unit Type!");
            }

            //if(model.GetInterfaces().Any(i=>i==typeof(IUnit)))

            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is Not a Unit Type!");
            }

            IUnit unit = (IUnit) Activator.CreateInstance(model);
            return unit;
        }
    }
}
