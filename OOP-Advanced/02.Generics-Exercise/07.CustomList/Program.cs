using System;

public class Program
{
    static void Main(string[] args)
    {
        var customList = new CustomList<string>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];
            switch (command)
            {
                case "Add":
                    customList.Add(commandArgs[1]);
                    break;
                case "Remove":
                    int index = int.Parse(commandArgs[1]);
                   customList.Remove(index);
                    break;
                case "Contains":
                    bool result = customList.Contains(commandArgs[1]);
                    Console.WriteLine(result);
                    break;
                case "Swap":
                    customList.Swap(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]));
                    break;
                case "Greater":
                    int count = customList.CountGreaterThan(commandArgs[1]);
                    Console.WriteLine(count);
                    break;
                case "Max":
                    string max = customList.Max();
                    Console.WriteLine(max);
                    break;
                case "Min":
                    string min = customList.Min();
                    Console.WriteLine(min);
                    break;
                case "Print":
                    for (int i = 0; i < customList.Count; i++)
                    {
                        Console.WriteLine(customList[i]);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}

