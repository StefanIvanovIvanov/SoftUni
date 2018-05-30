using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        ListyIterator<string> listyIterator = new ListyIterator<string>();
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                switch (command)
                {
                    case "Create":
                        listyIterator = new ListyIterator<string>(commandArgs.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        listyIterator.Print();
                        break;
                    case "PrintAll":
                        listyIterator.PrintAll();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

