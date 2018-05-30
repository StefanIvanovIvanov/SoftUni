using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public abstract class Command:ICommand
   {
       public IHarvesterController HarverstConstorller;
       public IProviderController ProverController;
        public IList<string> Arguments { get; }

       protected Command(IList<string> arguments, IHarvesterController harverstConstorller,
           IProviderController provierController)
       {
           this.Arguments = arguments;
           this.HarverstConstorller = harverstConstorller;
           this.ProverController = provierController;
       }

       public abstract string Execute();
   }

