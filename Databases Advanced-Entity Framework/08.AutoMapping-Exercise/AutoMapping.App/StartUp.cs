using System;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapping.App.Core;
using AutoMapping.App.Core.Contracts;
using AutoMapping.App.Core.Controllers;
using AutoMapping.Data;
using AutoMapping.Services;
using AutoMapping.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace AutoMapping.App
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //AutoMappingContext contect = new AutoMappingContext();

            IServiceProvider service = ConfigureService();

            IEngine engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<AutoMappingContext>(opts => opts.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddAutoMapper(conf=>conf.AddProfile<AutoMapperProfile>());

            serviceCollection.AddTransient<IDbInitializerService, DbInitializerService>();

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();

            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();

            serviceCollection.AddTransient<IManagerController, ManagerController>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
