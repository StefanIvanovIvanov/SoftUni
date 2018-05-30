namespace _04.TreasureMap
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        private static List<string> instructions;

        static void Main(string[] args)
        {
            instructions = ReadAllInstructions();
            ParseInstructions();
        }

        private static List<string> ReadAllInstructions()
        {
            List<string> instructions = new List<string>();

            int numberOfInstructions = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInstructions; i++)
            {
                instructions.Add(Console.ReadLine());
            }

            return instructions;
        }

        private static void ParseInstructions()
        {
            string validInstructionPattern = @"[!#].*?\b(?<streetName>[a-zA-Z]{4})\b.*?(\d{3}-\d{6}|\d{4}).*?[!#]";

            for (int i = 0; i < instructions.Count; i++)
            {
                // get all valid instructions
                MatchCollection matches = Regex.Matches(instructions[i], validInstructionPattern);

                if (matches.Count == 0)
                {
                    continue;
                }

                int indexOfInstruction = (matches.Count % 2 == 0) ? matches.Count - 1 : matches.Count - 2;
                indexOfInstruction = indexOfInstruction < 0 ? 0 : indexOfInstruction;

                // match street number - password pair
                MatchCollection pairMatches = Regex.Matches(matches[indexOfInstruction].Value, @"(?<streetNumber>\d{3})-(?<password>\d{6}|\d{4})");

                string streetName = matches[indexOfInstruction].Groups["streetName"].Value;
                string streetNumber = pairMatches[pairMatches.Count - 1].Groups["streetNumber"].Value;
                string password = pairMatches[pairMatches.Count - 1].Groups["password"].Value;

                Console.WriteLine($"Go to str. {streetName} {streetNumber}. Secret pass: {password}.");
            }
        }
    }
}