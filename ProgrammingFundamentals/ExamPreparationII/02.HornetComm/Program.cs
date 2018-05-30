using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> privarMessages = new List<string>();
            List<string> broadcastMessages = new List<string>();

            string patternPriviteMassage = @"(^\d+)\s<->\s([A-Za-z0-9]+)$";
            string patternBroadCasts = @"(^\D+)\s<->\s([A-Za-z0-9]+)$";
            Regex broadCastsRegex = new Regex(patternBroadCasts);
            Regex privateMassageRegex = new Regex(patternPriviteMassage);

            while (true)
            {
                var inputLine = Console.ReadLine();
                if (inputLine == "Hornet is Green")
                {
                    break;
                }
                if (privateMassageRegex.IsMatch(inputLine))
                {
                    var match = privateMassageRegex.Match(inputLine);
                    var firstQuery = match.Groups[1].Value;
                    var massage = match.Groups[2].Value;
                    ProcessPrivatMessages(privarMessages, firstQuery, massage);
                }
                else
                {
                    if (broadCastsRegex.IsMatch(inputLine))
                    {
                        var match = broadCastsRegex.Match(inputLine);
                        var firstQuery = match.Groups[1].Value;
                        var secondQuery = match.Groups[2].Value;
                        ProcessBroadcastMessages(broadcastMessages, firstQuery, secondQuery);
                    }
                }
            }

            Console.WriteLine("Broadcasts:");
            if (broadcastMessages.Count <= 0)
                Console.WriteLine("None");
            else
            {
                for (int i = 1; i < broadcastMessages.Count; i += 2)
                {
                    Console.WriteLine($"{broadcastMessages[i - 1]} -> {broadcastMessages[i]}");
                }
            }
            Console.WriteLine("Messages:");
            if (privarMessages.Count <= 0)
                Console.WriteLine("None");
            else
            {
                for (int i = 1; i < privarMessages.Count; i += 2)
                {
                    Console.WriteLine($"{privarMessages[i - 1]} -> {privarMessages[i]}");
                }
            }
        }

        static void ProcessPrivatMessages(List<string> privarMessages, string firstQuery, string secondQuery)
        {
            var recipient = new string(firstQuery.ToArray().Reverse().ToArray());
            var message = secondQuery;

            privarMessages.Add(recipient);
            privarMessages.Add(message);
        }

        static void ProcessBroadcastMessages(List<string> broadcastMessages, string firstQuery, string secondQuery)
        {
            string message = firstQuery;
            string frequancy = secondQuery;

            StringBuilder newFrequancy = new StringBuilder();
            foreach (var ch in frequancy)
            {
                if (char.IsLetter(ch))
                {
                    if (char.IsUpper(ch))
                    {
                        newFrequancy.Append(char.ToLower(ch));
                    }
                    else
                    {
                        newFrequancy.Append(char.ToUpper(ch));
                    }
                }
                else
                {
                    newFrequancy.Append(ch);
                }
            }
            broadcastMessages.Add(newFrequancy.ToString());
            broadcastMessages.Add(message);
        }
    }
}