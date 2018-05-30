using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minedraft.Commands.Register
{
    class HarvesterCommand:Command
    {
        public HarvesterCommand(IList<string> arguments, IHarvesterController harverstConstorller, IProviderController provierController)
            : base(arguments, harverstConstorller, provierController)
        {
        }

        public override string Execute()
        {
            return this.HarverstConstorller.Register(this.Arguments);
        }
    }
}
