using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var stackArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(e => e.TrimEnd(','))
                .Skip(1)
                .ToArray();

        var stack = new Stack<string>(stackArgs);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] commandArgs = input.Split();
            string command = commandArgs[0];

            try
            {
                switch (command)
                {
                    case "Pop":
                        stack.Pop();
                        break;
                    case "Push":
                        var element = commandArgs.LastOrDefault();
                        stack.Push(element);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (string line in stack)
            {
                Console.WriteLine(line);
            }
        }
    }
}


