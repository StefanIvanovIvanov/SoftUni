using System;
using System.Collections.Generic;
using System.Text;
using AutoMapping.App.Core.Contracts;
using AutoMapping.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace AutoMapping.App.Core
{
    public class Engine:IEngine
    {
        private readonly IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var initializeDb = this.serviceProvider.GetService<IDbInitializerService>();
            initializeDb.InitializeDatabase();

            var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string result = commandInterpreter.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
