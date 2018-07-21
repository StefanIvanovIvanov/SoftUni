using System;
using System.Collections.Generic;
using System.Text;
using AutoMapping.App.Core.Contracts;

namespace AutoMapping.App.Core.Commands
{
   public class SetManagerCommand:ICommand
   {
       private readonly IManagerController managerController;

        public SetManagerCommand(IManagerController managerController)
        {
            this.managerController = managerController;
        }
        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            return "Command accomplished successfully";
        }
    }
}
