using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CommandInterpreter : ICommandInterpreter
{
    public IHarvesterController HarvesterController { get; }
    public IProviderController ProviderController { get; }
    private DraftManager manager = new DraftManager();

    public string ProcessCommand(IList<string> inputArgs)
    {
        var data = inputArgs;
        var command = data[0];
        switch (command)
        {
            case "RegisterHarvester":
                var args = new List<string>(data.Skip(1).ToList());
                manager.RegisterHarvester(args);
                break;
            case "RegisterProvider":
                args = new List<string>(data.Skip(1).ToList());
                manager.RegisterProvider(args);
                break;
            case "Day":
                manager.Day();
                break;
            case "Mode":
                args = new List<string>(data.Skip(1).ToList());
                manager.Mode(args);
                break;
            case "Check":
                args = new List<string>(data.Skip(1).ToList());
                //Console.WriteLine(manager.Check(args));
                break;
            default:
                manager.ShutDown();
                Environment.Exit(0);
                break;


           
        }
        return "";
    }
}

