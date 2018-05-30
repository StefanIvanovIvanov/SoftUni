using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class ModeCommand:Command
    {
        public ModeCommand(IList<string> arguments, IHarvesterController harverstConstorller, IProviderController provierController) : base(arguments, harverstConstorller, provierController)
        {
        }

        public override string Execute()
        {
            string mode = this.HarverstConstorller.ChangeMode(this.Arguments[0]);

            return mode;
        }
    }

