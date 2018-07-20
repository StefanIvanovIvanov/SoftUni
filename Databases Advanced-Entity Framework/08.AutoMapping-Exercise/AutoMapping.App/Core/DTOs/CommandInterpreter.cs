using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapping.App.Core.Contracts;

namespace AutoMapping.App.Core.Controllers
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public string Read(string[] input)
        {
            string commandName = input[0] + "Command";


            string[] args = input.Skip(1).ToArray();

            var type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == commandName);

            var contructor = type.GetConstructors().First();

            var constructorParameters = contructor.GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var service = constructorParameters.Select(serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)contructor.Invoke(service);

            string result = command.Execute(args);

            return result;
        }
    }
}
