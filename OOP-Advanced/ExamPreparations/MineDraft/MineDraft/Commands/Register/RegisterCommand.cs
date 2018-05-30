using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


    public class RegisterCommand:Command
    {
        public RegisterCommand(IList<string> arguments, IHarvesterController harverstConstorller, IProviderController providerController)
        : base(arguments, harverstConstorller, providerController)
        {
        }

        public override string Execute()
        {
            var args=new LinkedList<string>(this.Arguments.Skip(1));

        Assembly assembly=Assembly.GetExecutingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == this.Arguments[0] + "Command");

        object[] consrtArgs=new object[]{args, this.HarverstConstorller, this.ProverController};
            object instance = Activator.CreateInstance(commandType, this.HarverstConstorller, this.ProverController);


            return commandType.GetMethod("Execute").Invoke(instance, null).ToString();
        }
    }

