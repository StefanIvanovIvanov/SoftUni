using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StartUp
{
    static void Main()
    {
       

        NationsBuilder nationBuilder=new NationsBuilder();

        string input;
        while ((input = Console.ReadLine()) != "Quit")
        {
            List<string> commmandArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = commmandArgs[0];
            switch (command)
            {
                case "Bender":
                    nationBuilder.AssignBender(commmandArgs);
                    break;
                case "Monument":
                    nationBuilder.AssignMonument(commmandArgs);
                    break;
                case "Status":
                    string status = commmandArgs[1];
                    Console.WriteLine(nationBuilder.GetStatus(status));                  
                    break;
                case "War":
                    string nation = commmandArgs[1];
                    nationBuilder.IssueWar(nation);
                    break;
                default:
                    Console.WriteLine("No such command");
                    break;
            }
        }
        Console.WriteLine(nationBuilder.GetWarsRecord());
    }
}

