using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        Team team = new Team("Name");
        for (int i = 0; i < lines; i++)
        {
            string[] cmdArgs = Console.ReadLine().Split();
           
                Person person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3]));
            team.AddPlayer(person);

        }
        Console.WriteLine($"First team has {team.FirstTeam.Count} players");
        Console.WriteLine($"Resesrve team has {team.ReserveTeam.Count} players");
    }
}

