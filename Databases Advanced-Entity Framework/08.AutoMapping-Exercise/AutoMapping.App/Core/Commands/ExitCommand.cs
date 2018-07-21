using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AutoMapping.App.Core.Contracts;

namespace AutoMapping.App.Core.Commands
{
  public  class ExitCommand:ICommand
  {
      private readonly IEmployeeController employeeController;

        public ExitCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }
        public string Execute(string[] args)
        {
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Program will close after {i} seconds");
                Thread.Sleep(1000);
            }

            Environment.Exit(0);

            return null;
        }
    }
}
