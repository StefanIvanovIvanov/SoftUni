using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _11.JediCode_X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> input=new List<string>();
            for (int i = 0; i < n; i++)
            {
                input.Add(Console.ReadLine());
            }
            string jediKey = Console.ReadLine();
            int jediKeyLength = jediKey.Length;

            string messageKey = Console.ReadLine();
            int messageKeyLength = messageKey.Length;
            int[] indexes = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string jediPattern =  jediKey+@"[?!A-Za-z]{"+ jediKeyLength+"}";
            string messagePattern = messageKey + @"[?!A-Za-z0-9]{" + messageKeyLength + "}";

            List<string>jedi=new List<string>();
            List<string>messages=new List<string>();

            foreach (string message in input)
            {
                MatchCollection jediMatches = Regex.Matches(message, jediPattern);
                MatchCollection messageMatches = Regex.Matches(message, messagePattern);

                foreach (Match m in jediMatches)
                {
                    string currentJedi = m.Value.Substring(jediKeyLength);
                 jedi.Add(currentJedi);   
                }

                foreach (Match m in messageMatches)
                {
                    string currentMessage = m.Value.Substring(messageKeyLength);
                    messages.Add(currentMessage);
                }
            }
           
            var result = new StringBuilder();

            int currentJediIndex = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] - 1 < jedi.Count && currentJediIndex < jedi.Count)
                {
                    result.AppendLine($"{jedi[currentJediIndex]} - {messages[indexes[i] - 1]}");
                    currentJediIndex++;
                }
            }

            Console.Write(result);

        }
    }
}
