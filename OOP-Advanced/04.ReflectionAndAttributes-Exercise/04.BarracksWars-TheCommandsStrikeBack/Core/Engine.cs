using System.Reflection;
using System.Linq;
namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

            if (commandType == null)
            {
                throw new ArgumentException("Invalid commend!");
            }

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"{commandName} Is Not A Command!");
            }

            MethodInfo method = typeof(IExecutable).GetMethods().First();


            Object[] constrArgs = new object[] { data, this.repository, this.unitFactory };
            Object instance = Activator.CreateInstance(commandType, constrArgs);
            try
            {
                string result = (string)method.Invoke(instance, null);
                return result;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
            
        }

        //copied over in the Commands folder
        /* private string ReportCommand(string[] data)
         {
             string output = this.repository.Statistics;
             return output;
         }


         private string AddUnitCommand(string[] data)
         {
             string unitType = data[1];
             IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
             this.repository.AddUnit(unitToAdd);
             string output = unitType + " added!";
             return output;
         }*/
    }
}
