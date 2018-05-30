using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.PhonebookUpgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> command = Console.ReadLine().Split().ToList();
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();

            List<string> result = new List<string>();
            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "A":
                        phonebook[command[1]] = command[2];
                        break;

                    case "S":
                        if (phonebook.ContainsKey(command[1]))
                        {
                            result.Add($"{command[1]} -> {phonebook[command[1]]}");
                        }
                        else
                        {
                            result.Add($"Contact {command[1]} does not exist.");
                        }

                        break;

                    case "ListAll":
                        foreach (KeyValuePair<string, string> kvp in phonebook)
                        {
                            result.Add($"{kvp.Key} -> {kvp.Value}");
                        }

                        break;
                }

                command = Console.ReadLine().Split(' ').ToList();
            }

            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }
    }
}