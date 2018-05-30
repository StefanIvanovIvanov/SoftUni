using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager manager;

    private CommandInterpreter commandInterpreter;

    public Engine()
    {
        this.manager = new DraftManager();
        this.commandInterpreter=new CommandInterpreter();
    }

    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine();
            var data = input.Split().ToList();
            //
            commandInterpreter.ProcessCommand(data);     
        }
    }
}
