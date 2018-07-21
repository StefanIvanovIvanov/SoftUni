using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using AutoMapping.App.Core.Contracts;
using ICommand = AutoMapping.App.Core.Contracts.ICommand;

namespace AutoMapping.App.Core.Commands
{
    public class SetAdressCommand : ICommand
    {
        private readonly IEmployeeController employeeController;

        public SetAdressCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }

        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            string address = args[1];

            this.employeeController.SetAddress(id, address);

            return "Command accomplished successfully!";
        }
    }
}
